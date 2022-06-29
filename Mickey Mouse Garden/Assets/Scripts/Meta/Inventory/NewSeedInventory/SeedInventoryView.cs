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
        
        public NewGrowSlot[] GrowSlotsPrefabs;
        
        private List<NewGrowSlot> harvestableSlots = new List<NewGrowSlot>();
        private NewSeedInventory _seedInventory;

        private void Start() {
            _seedInventory = NewSeedInventory.Instance;
            SubscribeToBrokerMessages();
            DisplayInventoryItems();
        }
        
        private void SubscribeToBrokerMessages() {
            Broker.Subscribe<ItemCollectedMessage<NewSeed>>(OnSeedAdded);
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

            if (_seedInventory.PlantedSeeds is not {Count: > 0}) return;
            foreach (var seed in _seedInventory.PlantedSeeds) {
                InstantiateGrowSlot(seed);
            }
        }

        private void InstantiateGrowSlot(NewSeed seed) {
            var slotToInstantiate = GrowSlotsPrefabs.First(prefab => prefab.rarity == seed.Rarity);
            var slotClone = Instantiate(slotToInstantiate, growSlotItemParent.transform, false);
            slotClone.SetUp(seed);
        }
        
        private void UpdateSeedCount(Rarity rarity) {
            var slotToUpdate = SeedSlots.FirstOrDefault(slot => slot.Rarity == rarity);
            var numberOfSeeds = _seedInventory.InventoryList.Items.Count(seed => seed.Rarity == rarity);
            slotToUpdate.UpdateCountText(numberOfSeeds);
        }
        
        private void OnSeedAdded(ItemCollectedMessage<NewSeed> message) {
            UpdateSeedCount(message.Item.Rarity);
        }
        
        public void PlantSeed(PlantSeedMessage message) {
            Rarity rarityToPlant = message.SeedRarity;
            NewSeed seed;

            try {
                seed = _seedInventory.InventoryList.Items.First(newSeed => newSeed.Rarity == rarityToPlant);
            }
            catch (Exception e) {
                e = new Exception($"You have no {rarityToPlant.ToString()} seeds to plant");
                Debug.LogException(e);
                return;
            }

            _seedInventory.Remove(seed);
            UpdateSeedCount(rarityToPlant);
            
            _seedInventory.PlantedSeeds.Add(seed);
            InstantiateGrowSlot(seed);
        }
        
        private void HarvestOperations(NewGrowSlot growSlot) {
            RemoveFromHarvestable(growSlot);
            growSlot.Destroy();
            PlantSpawn(growSlot.rarity);
        }
        
        public void HarvestAll() {
            if (harvestableSlots.Count > 0) {
                for (int i = harvestableSlots.Count - 1; i >= 0; i--) {
                    if (!harvestableSlots[i].ReadyToHarvest) continue;
                    if (harvestableSlots[i] == null) continue;
                    HarvestOperations(harvestableSlots[i]);
                }
            } else {
                Debug.Log("No seeds to harvest");
            }
        }
        
        private void PlantSpawn(Rarity rarity) {
            var spawnMessage = new SpawnCardFromSeed(rarity);
            Broker.InvokeSubscribers(spawnMessage.GetType(), spawnMessage);
        }

        private void AddToHarvestable(GrowSlotReadyToHarvestMessage growSlotReadyToHarvestMessage) {
            harvestableSlots.Add(growSlotReadyToHarvestMessage.GrowSlot);
        }
        
        private void RemoveFromHarvestable(NewGrowSlot growSlot) {
            harvestableSlots.Remove(growSlot);
        }
        
        private void Harvest(NewGrowSlot growSlot) {
            HarvestOperations(growSlot);
        }
        
        private void Harvest(HarvestSlotMessage message) {
            HarvestOperations(message.GrowSlot);
        }

        private void OnDestroy() {
            Broker.Unsubscribe<ItemCollectedMessage<NewSeed>>(OnSeedAdded);
            Broker.Unsubscribe<PlantSeedMessage>(PlantSeed);
            Broker.Unsubscribe<GrowSlotReadyToHarvestMessage>(AddToHarvestable);
            Broker.Unsubscribe<HarvestSlotMessage>(Harvest);
        }
    }
}