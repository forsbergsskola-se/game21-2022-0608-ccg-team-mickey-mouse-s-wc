using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Interfaces;
using Meta.Seeds;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventory : Inventory<Seed> {
        [SerializeField] private SeedInventoryUI seedInventoryUIInventory;
        public static SeedInventory Instance;
        public override List<Seed> inventory { get; set; } = new();
        public List<Seed> growingSeeds = new();

        #region Singleton
        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of SeedInventory found! This is not allowed.");
                return;
            }

            Instance = this;
        }
        
        #endregion

        private void Start() {
            InitBase();
            Broker.Subscribe<PlantSeedMessage>(PlantSeed); // Maybe move to own method later
        }

        public override void CollectOperations(Seed objInventoryItem) {
            seedInventoryUIInventory.UpdateSeedCount(GetSeedCountOfRarity(objInventoryItem.rarity), objInventoryItem.rarity);
        }

        private int GetSeedCountOfRarity(Rarity rarity) {
            return inventory.Count(seed => seed.rarity == rarity);
        }
        
        public void PlantSeed(PlantSeedMessage objInventoryItem) {
            Rarity rarity = objInventoryItem.SeedRarity;
            Seed seedToPlant = null;

            try {
                seedToPlant = inventory.First(seed => seed.rarity == rarity);
            }
            catch (Exception e) {
                Debug.Log("Seed didn't exist in inventory"); //TODO: Display error message to player
                return;
            }

            inventory.Remove(seedToPlant); //Might be inventory responsibility, add OnItemRemoved in inventory if this pattern occurs in several inventories
            seedInventoryUIInventory.UpdateSeedCount(GetSeedCountOfRarity(rarity), rarity);
            growingSeeds.Add(seedToPlant);
        }


        //TODO list
        //Instaniate slot w timer set
        //Scrollbox for grow slots
        //Remove sliding for slider
        //Show progress in slider
        //Remove from growing list onHarvest ( called on onclick), maybe enable button first when growth timer reached 0
        //
        



        //TODO: Unsubscribe from broker
    }
}