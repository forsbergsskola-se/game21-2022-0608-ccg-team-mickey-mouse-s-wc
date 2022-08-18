using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class Seed : IInventoryItem {
        public Rarity rarity; // Can possibly be extracted out now that we have LibraryID.

        public Rarity Rarity{
            get => rarity;
            set => rarity = value;
        }

        public DateTime HarvestTime { get; set; }
        public StringGUID ID { get; }
        public string libraryID{ get; set; }

        public Seed() {
            ID = new StringGUID().NewGuid();
        }

        public async void TryLoadData(){
            var loadedSeed = await SaveManager.Load<Seed>(ID);
            if (loadedSeed == null){
                return;
            }
            this.CopyAllValuesFrom(loadedSeed);
        }

        public void Save() {
           SaveManager.Save(this);
        }
    }
}