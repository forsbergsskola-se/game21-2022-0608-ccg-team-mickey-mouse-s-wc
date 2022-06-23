using System;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    /// <summary>
    /// The serialized data of all cards belonging to the player.
    /// </summary>
    [System.Serializable]
    public class CardInventory : Inventory<Card> {
        public override List<Card> InventoryItems { get; set; } = new();
        public IEnumerable<Card> Cards => InventoryItems;
        public static CardInventory Instance { get; private set; }

        private void Awake() {
            if (Instance != null) {
                Debug.LogWarning("More than one instance of CardInventory found! This is not allowed.");
            } else {
                /*TODO: Implement marc's way <- For Oliver
                if (instance == null) {
                    //if (has saved inventory)
                    //load that
                    //else new CardInventory instance
                }
                */
                Instance = this;
            }
        }

        private void Start() {
            InitBase();
        }

        public override void CollectOperations(Card addedItem) {
            var cardAddedMessage = new CardAddedToInventoryMessage(addedItem);
            Broker.InvokeSubscribers(cardAddedMessage.GetType(), cardAddedMessage);
            
            //TODO: Save
            
            Debug.Log("This was collected" + addedItem.cardId);
            Debug.Log("Inventory count is" + InventoryItems.Count);
        }
    }
}