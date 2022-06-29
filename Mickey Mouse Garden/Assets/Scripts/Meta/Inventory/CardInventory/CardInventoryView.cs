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
        public CardLibraryConfig cardLibrary; //TODO: Break out in "data manager" (singleton), monobehaviour

        //TODO: On open
        private void Start() {
            var cardInventory = CardInventory.Instance;
            Broker.Subscribe<CardAddedToInventoryMessage>(OnCardAdded);

            if (cardInventory.Items.Count > 0) {
                foreach (var card in cardInventory.Items) {
                    OnCardAdded(card);
                }
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
            var cardValues = cardLibrary.cards.Single(it => it.id == card.libraryID);
            cardInstance.Configure(cardValues);
        }
    }
}