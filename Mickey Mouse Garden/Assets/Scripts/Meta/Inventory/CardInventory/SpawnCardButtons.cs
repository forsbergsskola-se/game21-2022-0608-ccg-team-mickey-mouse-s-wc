using Meta.Cards;
using UnityEngine;

public class SpawnCardButtons : MonoBehaviour{
   [SerializeField] private GameObject cardButtonPrefab;
   private CardConfig[] playerCardTeam;

   private void Awake(){
      playerCardTeam = FindObjectOfType<CardInventoryMockup>().playerCards;
      for (var i = 0; i < 3; i++){
         var instance = Instantiate(cardButtonPrefab, gameObject.transform);
         instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
      }
   }
}
