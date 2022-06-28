using System.Collections.Generic;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class NewSeedInventory : Inventory<NewSeed> {
        public override List<NewSeed> Items { get; set; } = new List<NewSeed>();
        public List<NewSeed> PlantedSeeds { get; set; } = new List<NewSeed>();

        public static NewSeedInventory Instance { get; private set; }

        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of new seed inventory found! This is not allowed.");
            } else {
                //TODO: Implement marc's way, loading in saved file<- For Oliver
                Instance = this;
            }
        }

        private void Start() {
            InitBase();
        }
        
        public override void CollectOperations(NewSeed addedItem) {
            //TODO: Save
        }
    }
}