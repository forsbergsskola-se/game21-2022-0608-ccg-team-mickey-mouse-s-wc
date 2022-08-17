using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Cards;
using Meta.Inventory.NewSeedInventory.Messages;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    public class SeedInventoryView : MonoBehaviour {
        public SeedSlotContainer[] SeedSlots;
        [SerializeField] private GameObject growSlotItemParent;
        
        public GrowSlot[] GrowSlotsPrefabs;
        
        private List<GrowSlot> harvestableSlots = new List<GrowSlot>();
        private SeedInventory _seedInventory;

        private void Start() {
            _seedInventory = FindObjectOfType<Player>().GetComponent<SeedInventory>();
            SubscribeToBrokerMessages();
            DisplayInventoryItems();
        }
        
        private void SubscribeToBrokerMessages() {
            Broker.Subscribe<AddItemToInventoryMessage<Seed>>(OnSeedAdded);
            Broker.Subscribe<PlantSeedMessage>(PlantSeed);
            Broker.Subscribe<GrowSlotReadyToHarvestMessage>(AddToHarvestable);
            Broker.Subscribe<HarvestSlotMessage>(Harvest);
        }
        
        private void DisplayInventoryItems() {
            if (_seedInventory.InventoryList.Items is {Count: > 0})
            {
                foreach (Rarity rarity in Enum.GetValues(typeof(Rarity))) {
                    UpdateSeedCount(rarity);
                }
            }
            
            _seedInventory.PlantedSeeds.TryLoadData();

            if (_seedInventory.PlantedSeeds.Items is {Count: > 0}) {
                foreach (var seed in _seedInventory.PlantedSeeds.Items) {
                    InstantiateGrowSlot(seed);
                }
            }
        }

        private void InstantiateGrowSlot(Seed seed) {
            var slotToInstantiate = GrowSlotsPrefabs.First(prefab => prefab.rarity == seed.Rarity);
            var slotClone = Instantiate(slotToInstantiate, growSlotItemParent.transform, false);
            slotClone.SetUp(seed);

            _seedInventory.PlantedSeeds.Save();
        }
        
        private void UpdateSeedCount(Rarity rarity) {
            var slotToUpdate = SeedSlots.FirstOrDefault(slot => slot.Rarity == rarity);
            var numberOfSeeds = _seedInventory.InventoryList.Items.Count(seed => seed.Rarity == rarity);
            slotToUpdate.UpdateCountText(numberOfSeeds); //If null ref occur, make sure the seed slots have set rarity in inspector
        }
        
        private void OnSeedAdded(AddItemToInventoryMessage<Seed> message) {
            UpdateSeedCount(message.item.rarity);
        }

        private void PlantSeed(PlantSeedMessage message) {
            Rarity rarityToPlant = message.SeedRarity;
            Seed seed;

            try {
                seed = _seedInventory.InventoryList.Items.First(newSeed => newSeed.Rarity == rarityToPlant);
            }
            catch (Exception e) {
                return;
            }

            _seedInventory.Remove(seed);
            UpdateSeedCount(rarityToPlant);
            
            InstantiateGrowSlot(seed);
            
            _seedInventory.PlantedSeeds.Items.Add(seed);
            _seedInventory.PlantedSeeds.Save();
        }
        
        private void HarvestOperations(GrowSlot growSlot) {
            RemoveFromHarvestable(growSlot);
            RequestCardSpawn(growSlot.rarity);
            
            var seedToRemove =
                _seedInventory.PlantedSeeds.Items.FirstOrDefault(seed =>
                    seed.rarity == growSlot.rarity);
            
            _seedInventory.PlantedSeeds.Items.Remove(seedToRemove);
            _seedInventory.PlantedSeeds.Save();
            
            growSlot.Destroy();
        }
        
        public void HarvestAll(){
            if (harvestableSlots.Count <= 0) return;
            for (var i = harvestableSlots.Count - 1; i >= 0; i--) {
                if (!harvestableSlots[i].ReadyToHarvest) continue;
                if (harvestableSlots[i] == null) continue;
                HarvestOperations(harvestableSlots[i]);
            }
        }
        
        private void RequestCardSpawn(Rarity rarity) {
            var spawnMessage = new SpawnCardFromSeed(rarity);
            Broker.InvokeSubscribers(spawnMessage.GetType(), spawnMessage);
        }

        private void AddToHarvestable(GrowSlotReadyToHarvestMessage growSlotReadyToHarvestMessage) {
            harvestableSlots.Add(growSlotReadyToHarvestMessage.GrowSlot);
        }
        
        private void RemoveFromHarvestable(GrowSlot growSlot) {
            harvestableSlots.Remove(growSlot);
        }
        private void Harvest(HarvestSlotMessage message) {
            HarvestOperations(message.GrowSlot);
        }

        private void OnDestroy() {
            Broker.Unsubscribe<AddItemToInventoryMessage<Seed>>(OnSeedAdded);
            Broker.Unsubscribe<PlantSeedMessage>(PlantSeed);
            Broker.Unsubscribe<GrowSlotReadyToHarvestMessage>(AddToHarvestable);
            Broker.Unsubscribe<HarvestSlotMessage>(Harvest);
        }
    }
}