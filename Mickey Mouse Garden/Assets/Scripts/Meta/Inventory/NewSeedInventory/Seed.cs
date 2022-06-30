using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class Seed : IInventoryItem, ISaveData {
        public Rarity rarity; // Can possibly be extracted out now that we have LibraryID.

        public Rarity Rarity{
            get => rarity;
            set => rarity = value;
        }

        public DateTime HarvestTime { get; set; }
        public bool ReadyToHarvest { get; set; } //TODO: Check if timer handles setting bool correctly or if seed needs to set
        public StringGUID ID { get; }
        public string libraryID{ get; set; }

        public Seed() {
            ID = new StringGUID().NewGuid();
        }

        public async void TryLoadData(){
            await SaveManager.Load<Seed>(ID);
        }

        public void Save() {
           SaveManager.Save(this);
        }

        
    }
}