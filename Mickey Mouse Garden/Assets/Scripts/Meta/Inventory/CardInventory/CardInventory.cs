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
        public override InventoryList<Card> InventoryList { get; set; } = new InventoryList<Card>(new StringGUID().CreateStringGuid(10101));
        public static CardInventory Instance { get; private set; }
        public override void CollectOperations(Card addedItem) {
            base.CollectOperations(addedItem);
            
            var cardAddedMessage = new CardAddedToInventoryMessage(addedItem);
            Broker.InvokeSubscribers(cardAddedMessage.GetType(), cardAddedMessage);
        }
    }
}