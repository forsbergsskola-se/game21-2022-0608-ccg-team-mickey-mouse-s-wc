using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InstantiateFilteredCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private void Awake(){
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        Broker.Subscribe<FusionStartMessage>(OnFusionStartMessage);
    }

    private void OnFusionStartMessage(FusionStartMessage obj){
        for (var i = 0; i < playerCardTeam.Count; i++){
            var instance = Instantiate(cardButtonPrefab, gameObject.transform);
            instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
        } 
    }
    
}
