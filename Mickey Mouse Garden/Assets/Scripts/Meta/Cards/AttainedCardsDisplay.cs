using System.Collections.Generic;
using Meta.Inventory.FighterInventory;
using TMPro;
using UnityEngine;

namespace Meta.Cards {
    public class AttainedCardsDisplay : MonoBehaviour {
        [SerializeField] private CardView cardViewPrefab;
        [SerializeField] private GameObject canvas;
        [SerializeField] private TextMeshProUGUI amountOfCardsText;
        
        private bool isOpen;
        private int index;
        
        private List<Card> attainedCards = new();
        
        private void Awake() {
            Broker.Subscribe<AddItemToInventoryMessage<Card>>(CardReceived);
        }

        private void CardReceived(AddItemToInventoryMessage<Card> card) {
            attainedCards.Add(card.item);
            UpdateText();
            
            if (isOpen) return;

            DisplayReceivedCard();
            
            isOpen = true;
        }
        
        private void DisplayReceivedCard() {
            canvas.SetActive(true);
            cardViewPrefab.Configure(attainedCards[index]);
        }

        public void Continue() {
            if (attainedCards.Count - 1 > index) {
                cardViewPrefab.Configure(attainedCards[++index]);
                UpdateText();
            } else {
                CloseCanvas();
            }
        }

        public void CloseCanvas() {
            isOpen = false;
            canvas.SetActive(false);
            attainedCards.Clear();
        }

        private void UpdateText() {
            amountOfCardsText.text = $"New Cards \n {index + 1} / {attainedCards.Count}";
        }
    }
}