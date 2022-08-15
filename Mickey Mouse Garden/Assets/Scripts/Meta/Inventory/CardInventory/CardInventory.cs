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
        public override void CollectOperations(Card addedItem) {
            base.CollectOperations(addedItem);
            
            var cardAddedMessage = new CardAddedToInventoryMessage(addedItem);
            Broker.InvokeSubscribers(cardAddedMessage.GetType(), cardAddedMessage);
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
    public static void SortByRarityASC(this InventoryList<Card> inventory, int leftIndex, int rightIndex) {
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
                (inventory.Items[i].Rarity, inventory.Items[j].Rarity) = (inventory.Items[j].Rarity, inventory.Items[i].Rarity);
                i++;
                j--;
            }
        }
        
        if(leftIndex < j) {
            SortByRarityASC(inventory, leftIndex, j);
        }
        
        if(i < rightIndex) {
            SortByRarityASC(inventory, i, rightIndex);
        }
    }
}