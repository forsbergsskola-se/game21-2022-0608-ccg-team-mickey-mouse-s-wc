using System.Linq;
using Meta.Cards;
using UnityEngine;

public class SelectedCard : MonoBehaviour{
   private int position;

   private CardConfig[] playerCardTeam;

   private void Awake(){
      playerCardTeam = FindObjectOfType<CardInventoryMockup>().playerCards;
      Broker.Subscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
   }

   public void IsSelected(){
      var name= GetComponentInChildren<CardView>().name.text;
      var msg = new CardSelectionMessage();
      msg.Position = position;
      msg.SelectionPanelActive = false;
      msg.SentCardConfig = playerCardTeam[0];
   }
   private void OnSelectedCardMessageReceived(CardSelectionMessage obj){
      position = obj.Position;
   }
}
