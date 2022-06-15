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
            seedInventoryUIInventory.UpdateUISlotCount(GetSeedCountOfRarity(objInventoryItem.rarity), objInventoryItem.rarity);
        }

        private int GetSeedCountOfRarity(Rarity rarity) {
            return inventory.Count(seed => seed.rarity == rarity);
        }
        
        public void PlantSeed(PlantSeedMessage obj) {
            Rarity rarity = obj.SeedRarity;
            Debug.Log(name + " got a message that a seed should be planted");
            //Could use linq find
            
            //Use rarity to move an object from inventory to growing seeds
        }
        
        //(Inventory resp) move to the groowingseedlist
        
        
        //TODO list
        //PlantSeed should move the first instance of a type found and set it to the growingseeds
        //For now only display with debug log that it was moved, that the grow list has correct count, worry about displaying it nicely later
        
        //TODO: Move seedinventory elsewhere in scene shouldn't be on the UI
        //TODO: Unsubscribe from broker
    }
}