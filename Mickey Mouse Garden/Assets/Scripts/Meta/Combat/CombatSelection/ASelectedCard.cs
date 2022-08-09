using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class ASelectedCard : MonoBehaviour{
   private int position;
   private Card cardData;
   private Card[] playerCardInventory;
   
   private void Awake(){
      Broker.Subscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
      playerCardInventory = FindObjectOfType<CardInventoryMockup>().playerCards; //TODO: Replace with actual player card inventory
   }

   public void WhenClicked(){
      cardData = FindCardData();
      CreateSelectedCardMessage();
      //finds the parent canvas, then finds the selectionPanel parent of that canvas. then sets that selectionpanel to inactive.
      transform.parent.transform.parent.gameObject.SetActive(false);
   }

   private void OnSelectedCardMessageReceived(CardSelectionMessage obj){
      position = obj.Position;
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
