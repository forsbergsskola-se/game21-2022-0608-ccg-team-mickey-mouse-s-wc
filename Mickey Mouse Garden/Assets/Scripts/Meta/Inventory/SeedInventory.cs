using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Interfaces;
using Meta.Seeds;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventory : Inventory<Seed> {
        public override List<Seed> inventory { get; set; } = new();
        public List<Seed> growingSeeds = new();
        
        [SerializeField] private SeedInventoryUI seedInventoryUI;

        private static SeedInventory instance;
        private List<GrowSlot> harvestable = new();

        #region Singleton
        private void Awake() {
            if (instance != null) {
                Debug.LogWarning("More than one instance of SeedInventory found! This is not allowed.");
                return;
            }

            instance = this;
        }
        
        #endregion

        private void Start() {
            InitBase();
            Broker.Subscribe<PlantSeedMessage>(PlantSeed);
            Broker.Subscribe<ReadyToHarvestMessage>(AddToHarvestableList);
            Broker.Subscribe<RequestHarvestMessage>(Harvest);
        }

        public override void CollectOperations(Seed objInventoryItem) {
            seedInventoryUI.UpdateSeedCount(GetSeedCountOfRarity(objInventoryItem.rarity), objInventoryItem.rarity);
        }

        private int GetSeedCountOfRarity(Rarity rarity) {
            return inventory.Count(seed => seed.rarity == rarity);
        }
        
        public void PlantSeed(PlantSeedMessage objInventoryItem) {
            Rarity rarity = objInventoryItem.SeedRarity;
            Seed seedToPlant;

            try {
                seedToPlant = inventory.First(seed => seed.rarity == rarity);
            }
            catch (Exception e) {
                Debug.Log("You have no seeds to plant");
                return;
            }

            inventory.Remove(seedToPlant); //Might be inventory responsibility, add OnItemRemoved in inventory if this pattern occurs in several inventories
            seedInventoryUI.UpdateSeedCount(GetSeedCountOfRarity(rarity), rarity);
            
            growingSeeds.Add(seedToPlant);
            seedInventoryUI.PlantSeedOfType(seedToPlant.rarity);
        }

        private void AddToHarvestableList(ReadyToHarvestMessage readyToHarvestMessage) {
            harvestable.Add(readyToHarvestMessage.HarvestableGrowSlot);
        }

        private void Harvest(RequestHarvestMessage requestHarvestMessage) {
            requestHarvestMessage.GrowSlot.Harvest();
        }

        private void Harvest(GrowSlot growSlot) {
            growSlot.Harvest();
        }

        public void HarvestAll() {
            if (harvestable.Count > 0) {
                for (int i = harvestable.Count - 1; i >= 0; i--) {
                    if (!harvestable[i].readyToHarvest) continue;
                    Harvest(harvestable[i]);
                    harvestable.RemoveAt(i);
                }
            } else {
                Debug.Log("No seeds to harvest");
            }
        }
        
        //TODO: Unsubscribe from events
    }
}