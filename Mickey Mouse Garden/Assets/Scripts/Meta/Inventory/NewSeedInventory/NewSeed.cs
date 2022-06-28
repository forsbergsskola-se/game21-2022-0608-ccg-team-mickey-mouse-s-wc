using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class NewSeed : MonoBehaviour, IInventoryItem, ISaveData {
        public Rarity rarity;

        private void Awake() {
            Rarity = rarity;
        }

        //TODO: Only monobehaviour for quick testing, should be abstract
        //Currently made for the test spheres in the game, this method can be changed, and should be switched from OnMouseDown (unity event function) to something else
        private void OnMouseDown() {
            var collectedMessage = new ItemCollectedMessage<NewSeed>(this); //<--- Needed
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage); //<--- Needed
            Destroy(gameObject); //<--- Not needed
        }
        
        public Rarity Rarity { get; set; }
        public DateTime HarvestTime { get; set; }
        public bool ReadyToHarvest { get; set; }
        public StringGUID ID { get; }

        public void TryLoadData() {
            throw new System.NotImplementedException();
        }

        public void Save() {
            throw new System.NotImplementedException();
        }
    }
}