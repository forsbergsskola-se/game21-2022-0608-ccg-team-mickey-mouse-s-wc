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
        }

        public override void OnDisable(){
            base.OnDisable();
            Broker.Unsubscribe<SortCardInventoryByRarityMessage>(SortByRarity);
            Broker.Subscribe<SortCardInventoryByAlignmentMessage>(SortByAlignment);
        }

        public override void CollectOperations(Card addedItem) {
            base.CollectOperations(addedItem);
            
            var cardAddedMessage = new CardAddedToInventoryMessage(addedItem);
            Broker.InvokeSubscribers(cardAddedMessage.GetType(), cardAddedMessage);
        }


        public void SortByRarity(SortCardInventoryByRarityMessage sortCardInventoryByRarityMessage){
            InventoryList.SortByRarity(0, InventoryList.Items.Count - 1);
            InventoryList.Save();
        }

        public void SortByAlignment(SortCardInventoryByAlignmentMessage sortCardInventoryByAlignmentMessage){
            InventoryList.SortByAlignment(0, InventoryList.Items.Count - 1);
            InventoryList.Save();
        }
    }
}

public static class CardInventoryExtensions {
    
    /// <summary>
    /// Quicksort. Left index should be 0, right index should be lenght of list - 1.
    /// </summary>
    /// <param name="inventory"></param>
    /// <param name="leftIndex"></param>
    /// <param name="rightIndex"></param>
    /// <exception cref="Exception"></exception>
    public static void SortByRarity(this InventoryList<Card> inventory, int leftIndex, int rightIndex) {
        var i = leftIndex; 
        var j = rightIndex;
        var pivot = inventory.Items[leftIndex].Rarity;

        while (i <= j){
            while(inventory.Items[i].Rarity < pivot) {
                i++;
            }
            while(inventory.Items[j].Rarity > pivot) {
                j--;
            }

            if (i <= j){
                //Swaps the cards
                (inventory.Items[i], inventory.Items[j]) = (inventory.Items[j], inventory.Items[i]);
                i++;
                j--;
            }
        }
        
        if(leftIndex < j) {
            SortByRarity(inventory, leftIndex, j);
        }
        
        if(i < rightIndex) {
            SortByRarity(inventory, i, rightIndex);
        }
    }
    
    /// <summary>
    /// Quicksort. Left index should be 0, right index should be lenght of list - 1.
    /// </summary>
    /// <param name="inventory"></param>
    /// <param name="leftIndex"></param>
    /// <param name="rightIndex"></param>
    /// <exception cref="Exception"></exception>
    public static void SortByAlignment(this InventoryList<Card> inventory, int leftIndex, int rightIndex) {
        var i = leftIndex; 
        var j = rightIndex;
        var pivot = inventory.Items[leftIndex].Alignment;

        while (i <= j){
            while(inventory.Items[i].Alignment < pivot) {
                i++;
            }
            while(inventory.Items[j].Alignment > pivot) {
                j--;
            }

            if (i <= j){
                //Swaps the cards
                (inventory.Items[i], inventory.Items[j]) = (inventory.Items[j], inventory.Items[i]);
                i++;
                j--;
            }
        }
        
        if(leftIndex < j) {
            SortByAlignment(inventory, leftIndex, j);
        }
        
        if(i < rightIndex) {
            SortByAlignment(inventory, i, rightIndex);
        }
    }
}