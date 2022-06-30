using Meta.Cards;
using UnityEngine;

public class ASelectedCard : MonoBehaviour{
   private int position;
   private CardConfig cardData;
   private CardConfig[] playerCardInventory;
   
   private void Awake(){
      Broker.Subscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
      playerCardInventory = FindObjectOfType<CardInventoryMockup>().playerCards;
   }

   public void WhenClicked(){
      FindCardData();
      CreateSelectedCardMessage();
   }

   private void OnSelectedCardMessageReceived(CardSelectionMessage obj){
      position = obj.Position;
   }

   private void CreateSelectedCardMessage(){
      var msg = new CardSelectionMessage(){CardConfig = cardData, Position = position};
      Broker.InvokeSubscribers(typeof(CardSelectionMessage), msg);
   }


   private void FindCardData(){
      //crossreference playerinventory with the current card.
      var name = GetComponentInChildren<CardView>().name.text;
      foreach (var config in playerCardInventory){
         if (name != config.name) continue;
         cardData = config;
         return;
      }
   }
}
