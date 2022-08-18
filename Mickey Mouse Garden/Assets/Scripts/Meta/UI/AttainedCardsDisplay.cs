using System.Collections.Generic;
using Meta.Inventory.FighterInventory;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meta.Cards {
    public class AttainedCardsDisplay : MonoBehaviour {
        [SerializeField] private CardView cardViewPrefab;
        [SerializeField] private GameObject canvas;
        [SerializeField] private TextMeshProUGUI amountOfCardsText;
        
        private bool isOpen;
        private int index;
        
        private List<Card> attainedCards = new();
        
        private void OnEnable() {
            Broker.Subscribe<AddItemToInventoryMessage<Card>>(CardReceived);
        }
        
        private void OnDisable(){
            Broker.Unsubscribe<AddItemToInventoryMessage<Card>>(CardReceived);
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
        public void Reload(){ // Hardcoded, Script also should be split up into two different scripts.
            SceneManager.UnloadSceneAsync("Shed");
            SceneManager.LoadScene("Shed", LoadSceneMode.Additive);
        }

        public void CloseCanvas() {
            isOpen = false;
            canvas.SetActive(false);
            attainedCards.Clear();
            index = 0;
        }

        private void UpdateText() {
            if (amountOfCardsText == default){
                return;
            }
            amountOfCardsText.text = $"New Cards \n {index + 1} / {attainedCards.Count}";
        }
    }
}