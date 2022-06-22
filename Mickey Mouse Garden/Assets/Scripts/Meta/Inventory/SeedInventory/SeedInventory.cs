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

        private List<GrowSlot> harvestable = new();
        private static SeedInventory instance;

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
        
        public void PlantSeed(PlantSeedMessage seedToPlant) {
            Rarity rarity = seedToPlant.SeedRarity;
            Seed seedOfRequestedRarity;

            try {
                seedOfRequestedRarity = inventory.First(seed => seed.rarity == rarity);
            }
            catch (Exception e) {
                e = new Exception("You have no seeds to plant");
                Debug.LogException(e);
                return;
            }

            inventory.Remove(seedOfRequestedRarity); //Might be inventory responsibility, add OnItemRemoved in inventory if this pattern occurs in several inventories
            seedInventoryUI.UpdateSeedCount(GetSeedCountOfRarity(rarity), rarity);
            
            growingSeeds.Add(seedOfRequestedRarity);
            seedInventoryUI.PlantSeedOfType(seedOfRequestedRarity.rarity);
        }

        public override void CollectOperations(Seed objInventoryItem) {
            seedInventoryUI.UpdateSeedCount(GetSeedCountOfRarity(objInventoryItem.rarity), objInventoryItem.rarity);
        }

        private int GetSeedCountOfRarity(Rarity rarity) {
            return inventory.Count(seed => seed.rarity == rarity);
        }

        private void AddToHarvestableList(ReadyToHarvestMessage readyToHarvestMessage) {
            harvestable.Add(readyToHarvestMessage.HarvestableGrowSlot);
        }

        private void Harvest(RequestHarvestMessage requestHarvestMessage) {
            OnHarvest(requestHarvestMessage.GrowSlot);

        }

        private void Harvest(GrowSlot growSlot) {
            OnHarvest(growSlot);
        }

        public void HarvestAll() {
            if (harvestable.Count > 0) {
                for (int i = harvestable.Count - 1; i >= 0; i--) {
                    if (!harvestable[i].readyToHarvest) continue;
                    Harvest(harvestable[i]); //TODO: Gives null ref, should be fixed
                    harvestable.RemoveAt(i);
                }
            } else {
                Debug.Log("No seeds to harvest");
            }
        }

        private void OnHarvest(GrowSlot growSlot) {
            growSlot.RemoveEmpty();
            CardSpawner.SpawnFromSeed(growSlot.rarityType);
        }

        private void PlantSpawn(Rarity rarity) {
            CardSpawner.SpawnFromSeed(rarity);
        }
        
        private void OnDestroy() {
            Broker.Unsubscribe<PlantSeedMessage>(PlantSeed);
            Broker.Unsubscribe<ReadyToHarvestMessage>(AddToHarvestableList);
            Broker.Unsubscribe<RequestHarvestMessage>(Harvest);
        }
    }
}