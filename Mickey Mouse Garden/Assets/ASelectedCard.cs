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
      cardData = FindCardData();
      CreateSelectedCardMessage();
      transform.parent.transform.parent.gameObject.SetActive(false);
   }

   private void OnSelectedCardMessageReceived(CardSelectionMessage obj){
      position = obj.Position;
   }

   private void CreateSelectedCardMessage(){
      var msg = new NewCardSelectedMessage{CardConfig = cardData};
      Broker.InvokeSubscribers(typeof(NewCardSelectedMessage), msg);
   }


   public CardConfig FindCardData(){
      //crossreference player inventory with the current card.
      //TODO: dont compare to string compare to unique ID when that is implemented in cardconfig :)
      var name = GetComponentInChildren<CardView>().name.text;
      foreach (var config in playerCardInventory){
         if (name != config.name) continue;
         return config;
      }
      return cardData;
   }
}
