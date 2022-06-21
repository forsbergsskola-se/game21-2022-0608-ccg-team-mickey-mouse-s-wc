using System.Collections.Generic;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    public class CardInventory : Inventory<Card> {
        public Dictionary<StringGUID, OwnedCard> dictionary{ get; private set; } //TODO: Implement this instead of list
        public override List<Card> inventory { get; set; } = new();
        
        private static CardInventory instance;

        #region Singleton
        private void Awake() {
            if (instance != null) {
                Debug.LogWarning("More than one instance of CardInventory found! This is not allowed.");
                return;
            }

            instance = this;
        }
        
        #endregion

        private void Start() {
            InitBase();
        }
        
        public override void CollectOperations(Card objInventoryItem) {
            //TODO: Recieve from harvested seeds
            Debug.Log("This was collected" + objInventoryItem.Name);
            Debug.Log("Inventory count is" + inventory.Count);
        }
    }
}