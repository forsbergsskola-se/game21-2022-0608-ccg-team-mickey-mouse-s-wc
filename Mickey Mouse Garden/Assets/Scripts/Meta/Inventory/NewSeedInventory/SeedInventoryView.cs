using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Inventory.NewSeedInventory.Messages;
using Unity.VisualScripting;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    public class SeedInventoryView : MonoBehaviour {
        public SeedInventorySlotPrefabs[] SeedSlots;
        [SerializeField] private GameObject growSlotItemParent;
        
        public NewGrowSlotPrefabs[] GrowSlots;
        
        private List<NewGrowSlotPrefabs> harvestableSlots;
        private NewSeedInventory _seedInventory;

        private void Start() {
            _seedInventory = NewSeedInventory.Instance;
            SubscribeToMessages();
            DisplayInventoryItems();
        }
        
        public void PlantSeed(PlantSeedMessage message) {
            Rarity rarityToPlant = message.SeedRarity;
            NewSeed seed;

            try {
                seed = _seedInventory.Items.First(seed => seed.Rarity == rarityToPlant);
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

        private void UpdateSeedCount(Rarity rarity) {
            var slotToUpdate = SeedSlots.FirstOrDefault(slot => slot.Rarity == rarity);
            var numberOfSeeds = _seedInventory.Items.Count(seed => seed.Rarity == rarity);
            slotToUpdate.UpdateCountText(numberOfSeeds);
        }

        private void InstantiateGrowSlot(NewSeed seed) {
            var slotToInstantiate = GrowSlots.First(prefab => prefab.rarity == seed.Rarity);
            var slotClone = Instantiate(slotToInstantiate, growSlotItemParent.transform, false);
            slotClone.SetUp(seed);
        }

        private void AddToHarvestable(GrowSlotReadyToHarvestMessage growSlotReadyToHarvestMessage) {
            harvestableSlots.Add(growSlotReadyToHarvestMessage.GrowSlotPrefabs);
        }
        
        private void RemoveFromHarvestable(NewGrowSlotPrefabs growSlotPrefabs) {
            harvestableSlots.Remove(growSlotPrefabs);
        }
        
        public void HarvestAll() {
            if (harvestableSlots.Count > 0) {
                for (int i = harvestableSlots.Count - 1; i >= 0; i--) {
                    if (!harvestableSlots[i].readyToHarvest) continue;
                    if (harvestableSlots[i] == null) continue;
                    Harvest(harvestableSlots[i]);
                    harvestableSlots.RemoveAt(i);
                    harvestableSlots[i].Destroy();
                }
            } else {
                Debug.Log("No seeds to harvest");
            }
        }

        private void Harvest(NewGrowSlotPrefabs growSlotPrefabs) {
            RemoveFromHarvestable(growSlotPrefabs);
        }
        
        private void Harvest(HarvestSlotMessage message) {
            RemoveFromHarvestable(message.GrowSlotPrefabs);
        }

        private void OnSeedAdded(ItemCollectedMessage<NewSeed> message) {
            UpdateSeedCount(message.Item.Rarity);
        }

        private void DisplayInventoryItems() {
            if (_seedInventory.Items != null) { //TODO: This is quick fix for lists giving null ref
                if (_seedInventory.Items.Count > 0) {
                    foreach (Rarity rarity in Enum.GetValues(typeof(Rarity))) {
                        UpdateSeedCount(rarity);
                    }
                }
            }

            if (_seedInventory.PlantedSeeds != null) {
                if (_seedInventory.PlantedSeeds.Count <= 0) return;
                foreach (var seed in _seedInventory.PlantedSeeds) {
                    InstantiateGrowSlot(seed);
                }
            }
        }

        private void SubscribeToMessages() {
            Broker.Subscribe<ItemCollectedMessage<NewSeed>>(OnSeedAdded);
            Broker.Subscribe<PlantSeedMessage>(PlantSeed);
            Broker.Subscribe<GrowSlotReadyToHarvestMessage>(AddToHarvestable);
            Broker.Subscribe<HarvestSlotMessage>(Harvest);
        }

        private void OnDestroy() {
            //TODO: Unsubscribe
        }
    }
}