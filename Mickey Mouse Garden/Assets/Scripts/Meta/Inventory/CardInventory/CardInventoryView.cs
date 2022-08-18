using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Inventory.FighterInventory;
using UnityEngine;

namespace Meta.Cards {
    /// <summary>
    /// The view that's visible on a prefab and makes the card inventory interactable (input and output)
    /// </summary>
    [System.Serializable]
    public class CardInventoryView : MonoBehaviour {
        public CardView cardPrefab;
        public List<CardView> cards;
        public CardLibraryConfig cardLibrary;
        
        private void Awake() {
            Broker.Subscribe<CardAddedToInventoryMessage>(OnCardAdded);

            var inventoryList = FindObjectOfType<Player>().GetComponent<CardInventory>().InventoryList.Items;
            if (inventoryList.Count <= 0) return;
            
            foreach (var card in inventoryList) {
                OnCardAdded(card);
            }
        }

        private void OnCardAdded(CardAddedToInventoryMessage message) {
            InstantiateAndConfigCard(message.Card);
        }
        
        private void OnCardAdded(Card card) {
            InstantiateAndConfigCard(card);
        }
        
        private void InstantiateAndConfigCard(Card card) {
            var cardInstance = Instantiate(cardPrefab, transform);
            cardInstance.Configure(card);
        }
    }
}