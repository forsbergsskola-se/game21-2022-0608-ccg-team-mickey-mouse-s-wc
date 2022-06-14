using System;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Seeds;
using UnityEngine;

namespace Meta.Inventory {
    public class VegetableInventory : Inventory<Vegetable> {
        public static VegetableInventory Instance;
        public override List<Vegetable> inventory { get; set; } = new();
        
        #region Singleton
        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of VegetableInventory found! This is not allowed.");
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