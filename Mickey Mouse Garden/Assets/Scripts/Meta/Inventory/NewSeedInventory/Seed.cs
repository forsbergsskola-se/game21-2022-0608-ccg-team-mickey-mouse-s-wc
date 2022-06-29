using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class Seed :  IInventoryItem, ISaveData {
        public Rarity rarity;

        public Rarity Rarity{
            get => rarity;
            set => rarity = value;
        }

        public DateTime HarvestTime { get; set; }
        public bool ReadyToHarvest { get; set; } //TODO: Check if timer handles setting bool correctly or if seed needs to set
        public StringGUID ID { get; }

        public Seed() {
            ID = new StringGUID().NewGuid();
        }

        private void Awake() {
            Rarity = rarity;
        }

        public void TryLoadData() {
            throw new System.NotImplementedException();
        }

        public void Save() {
            throw new System.NotImplementedException();
        }
    }
}