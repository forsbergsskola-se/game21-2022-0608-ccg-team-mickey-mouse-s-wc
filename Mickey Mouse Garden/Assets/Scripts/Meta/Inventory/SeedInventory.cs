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
                Debug.Log("You have no seeds to plant"); //TODO: Display error message to player
                return;
            }

            inventory.Remove(seedToPlant); //Might be inventory responsibility, add OnItemRemoved in inventory if this pattern occurs in several inventories
            seedInventoryUI.UpdateSeedCount(GetSeedCountOfRarity(rarity), rarity);
            
            growingSeeds.Add(seedToPlant);
            seedInventoryUI.PlantSeedOfType(seedToPlant.rarity);
        }

        //TODO: Unsubscribe from broker
    }
}