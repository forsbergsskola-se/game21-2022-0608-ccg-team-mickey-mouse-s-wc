using System;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Seeds;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventory : Inventory<Seed> {
        public static SeedInventory Instance;
        public override List<Seed> inventory { get; set; } = new();
        
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
            Init();
        }
    }
}