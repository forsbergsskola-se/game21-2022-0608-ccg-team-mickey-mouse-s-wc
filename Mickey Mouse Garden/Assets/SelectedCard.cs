using Meta.Cards;
using UnityEngine;

public class SelectedCard : MonoBehaviour{
   public void IsSelected(){
      //send a message that a card has been selected?
      Debug.Log(GetComponentInChildren<CardView>().name.text);
   }
}
