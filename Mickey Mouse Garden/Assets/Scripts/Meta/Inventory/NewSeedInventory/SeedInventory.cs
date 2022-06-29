using System;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class SeedInventory : Inventory<Seed> {
        public override InventoryList<Seed> InventoryList { get; set; }
        public List<Seed> PlantedSeeds { get; set; } = new List<Seed>();

        public static SeedInventory Instance { get; private set; }

        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of new seed inventory found! This is not allowed.");
            } else {
                //TODO: Implement marc's way, loading in saved file<- For Oliver
                Instance = this;
            }
            Broker.Subscribe<AskForUpdateSeedUi>(SendUpdateSeedUiMessage);
        }

        private void OnDisable(){
            Broker.Unsubscribe<AskForUpdateSeedUi>(SendUpdateSeedUiMessage);
        }

        private void SendUpdateSeedUiMessage(AskForUpdateSeedUi message){
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }

        private void Start() {
            InitBase();
        }



        public override void CollectOperations(Seed addedItem) {
            //TODO: Save
        }
        public override void Add(Seed item){
            base.Add(item);
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }

        public override void Remove(Seed item){
            base.Remove(item);
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }
        //TODO: Send a number for updating UI instead of a list of seeds. Needs NewSeed to contain amount.
       
    }
}