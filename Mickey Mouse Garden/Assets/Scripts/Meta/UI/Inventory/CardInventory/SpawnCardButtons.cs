using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class SpawnCardButtons : MonoBehaviour {
   public CardView[] playerCardSlots;
   private List<Card> playerCardTeam;

   private void Awake(){
      playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
      for (var i = 0; i < playerCardSlots.Length; i++){
         playerCardSlots[i].Configure(playerCardTeam[i]);
      }
   }
}
