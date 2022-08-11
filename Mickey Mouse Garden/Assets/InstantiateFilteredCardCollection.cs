using System;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateFilteredCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private void OnEnable(){
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        Broker.Subscribe<FusionStartMessage>(OnFusionStartMessage);
    }

    private void OnDisable(){
        Broker.Unsubscribe<FusionStartMessage>(OnFusionStartMessage);
    }

    private void OnFusionStartMessage(FusionStartMessage obj){
        GetComponentInParent<Image>().enabled = true;
        for (var i = 0; i < playerCardTeam.Count; i++){
            //TODO: should filter on name and rarity and exclude itself
            if (playerCardTeam[i].Name == obj.fusionCard.Name && playerCardTeam[i].Rarity == obj.fusionCard.Rarity && playerCardTeam[i].ID != obj.fusionCard.ID){
                var instance = Instantiate(cardButtonPrefab, gameObject.transform);
                instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
            }
        } 
    }
    
}
