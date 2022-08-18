using System;
using Meta.Interfaces;

namespace Meta.Inventory.SeedInventory {
    [Serializable]
    public class Seed : IInventoryItem {
        public DateTime HarvestTime { get; set; }
        public StringGUID ID { get; }
        public string libraryID{ get; set; }
        public Rarity rarity;

        public Rarity Rarity{
            get => rarity;
            set => rarity = value;
        }

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