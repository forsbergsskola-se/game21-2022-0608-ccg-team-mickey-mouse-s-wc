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

        private void Start() {
            var cardInventory = CardInventory.Instance;
            Broker.Subscribe<CardAddedToInventoryMessage>(OnCardAdded);

            if (cardInventory.InventoryItems.Count > 0) {
                foreach (var card in cardInventory.InventoryItems) {
                    OnCardAdded(card);
                }
            }
        }

        private void OnCardAdded(CardAddedToInventoryMessage cardMessage) {
            var cardInstance = Instantiate(cardPrefab, transform);
            var card = cardMessage.Card;
            var cardValues = cardLibrary.cards.Single(it => it.id == card.cardId);
            cardInstance.Configure(cardValues);
        }
        
        private void OnCardAdded(Card card) {
            var cardInstance = Instantiate(cardPrefab, transform);
            var cardValues = cardLibrary.cards.Single(it => it.id == card.cardId);
            cardInstance.Configure(cardValues);
        }
    }
}