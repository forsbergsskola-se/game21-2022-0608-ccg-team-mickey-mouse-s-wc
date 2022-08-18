using System;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory;
using Meta.Inventory.FighterInventory;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    /// <summary>
    /// The serialized data of all cards belonging to the player.
    /// </summary>
    [System.Serializable]
    public class CardInventory : Inventory<Card> {
        public override InventoryList<Card> InventoryList { get; set; } = new InventoryList<Card>(new StringGUID().CreateStringGuid(10101));
        public static CardInventory Instance { get; private set; }

        public override void Awake(){
            base.Awake();
            Broker.Subscribe<SortCardInventoryByRarityMessage>(SortByRarity);
            Broker.Subscribe<SortCardInventoryByAlignmentMessage>(SortByAlignment);
            Broker.Subscribe<SortCardInventoryByNameMessage>(SortByName);
        }

        public override void OnDisable(){
            base.OnDisable();
            Broker.Unsubscribe<SortCardInventoryByRarityMessage>(SortByRarity);
            Broker.Unsubscribe<SortCardInventoryByAlignmentMessage>(SortByAlignment);
            Broker.Unsubscribe<SortCardInventoryByNameMessage>(SortByName);
        }

        public override void CollectOperations(Card addedItem) {
            base.CollectOperations(addedItem);
            
            var cardAddedMessage = new CardAddedToInventoryMessage(addedItem);
            Broker.InvokeSubscribers(cardAddedMessage.GetType(), cardAddedMessage);
        }

        public void SortByRarity(SortCardInventoryByRarityMessage sortCardInventoryByRarityMessage){
            InventoryList.SortByRarity();
            InventoryList.Save();
        }

        public void SortByAlignment(SortCardInventoryByAlignmentMessage sortCardInventoryByAlignmentMessage){
            InventoryList.SortByAlignment();
            InventoryList.Save();
        }
        public void SortByName(SortCardInventoryByNameMessage sortCardInventoryByNameMessage){
            InventoryList.SortByName();
            InventoryList.Save();
        }
    }
}

public static class CardInventoryExtensions {
    public static void SortByRarity(this InventoryList<Card> inventory) {
        inventory.Items.Sort((x,y) => y.Rarity.CompareTo(x.Rarity));
    }
    
    public static void SortByAlignment(this InventoryList<Card> inventory) {
        inventory.Items.Sort((x,y) => x.Alignment.CompareTo(y.Alignment));
    }
    
    public static void SortByName(this InventoryList<Card> inventory) {
        inventory.Items.Sort((x, y) => x.Name.CompareTo(y.Name));
    }
}