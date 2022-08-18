using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class ASelectedCard : MonoBehaviour{
   private Card cardData;
   private List<Card> playerCardInventory;
   
   private void Awake(){
      Broker.Subscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
      playerCardInventory = FindObjectOfType<CardInventory>().InventoryList.Items; //TODO: Replace with actual player card inventory
   }

   private void OnDisable(){
      Broker.Unsubscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
   }

   public void WhenClicked(){
      cardData = FindCardData();
      CreateSelectedCardMessage();
      
      //finds the parent canvas, then finds the selectionPanel parent of that canvas. then sets that selectionPanel to inactive.
      transform.parent.transform.parent.gameObject.SetActive(false);
   }

   private void OnSelectedCardMessageReceived(CardSelectionMessage obj){
   }

   private void CreateSelectedCardMessage(){
      var msg = new NewCardSelectedMessage{Card = cardData};
      Broker.InvokeSubscribers(typeof(NewCardSelectedMessage), msg);
   }
   
   public Card FindCardData(){
      //crossreference player inventory with the current card.
      var id = GetComponentInChildren<CardView>().id;
      foreach (var card in playerCardInventory){
         if (id != card.ID) continue;
         return card;
      }
      
      return cardData;
   }
}
