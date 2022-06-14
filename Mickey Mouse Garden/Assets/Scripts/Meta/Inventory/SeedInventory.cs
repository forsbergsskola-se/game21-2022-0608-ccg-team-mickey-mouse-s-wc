using System;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Seeds;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventory : Inventory {
        public static SeedInventory Instance;

        public override List<IInventoryItem> items { get; set; } = new();

        #region Singleton
        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of SeedInventory found!");
                return;
            }

            Instance = this;
        }
        
        #endregion
        
    }
}