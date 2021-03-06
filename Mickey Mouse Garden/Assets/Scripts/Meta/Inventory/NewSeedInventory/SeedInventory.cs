using System.Collections.Generic;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class SeedInventory : Inventory<Seed> {
        public override InventoryList<Seed> InventoryList { get; set; } = new InventoryList<Seed>(new StringGUID().CreateStringGuid(20202));
        public InventoryList<Seed> PlantedSeeds { get; set; } = new InventoryList<Seed>(new StringGUID().CreateStringGuid(30303));

        public static SeedInventory Instance { get; private set; }

        public override void Awake() {
            base.Awake();
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

        //TODO: Send a number for updating UI instead of a list of seeds. Needs NewSeed to contain amount.
        public override void CollectOperations(Seed addedItem) {
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
            //TODO: Save
        }

        public override void RemoveOperations(Seed removedItem) {
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }
    }
}