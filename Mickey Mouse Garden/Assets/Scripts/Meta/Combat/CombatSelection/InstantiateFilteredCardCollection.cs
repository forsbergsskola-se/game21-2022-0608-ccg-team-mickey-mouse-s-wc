using System;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateFilteredCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab, noCardsAvailable;
    private List<Card> playerCardTeam;
    private int cardsInstantiated;
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
            if (IsSameCardType(i, obj) && !IsMaxLevel(i, obj)){
                var instance = Instantiate(cardButtonPrefab, gameObject.transform);
                instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
                cardsInstantiated++;
            }
        }
        if (cardsInstantiated == 0){
            noCardsAvailable.SetActive(true);
        }
    }

    private bool IsSameCardType(int i, FusionStartMessage obj){
        return playerCardTeam[i].Name == obj.fusionCard.Name && playerCardTeam[i].Rarity == obj.fusionCard.Rarity && playerCardTeam[i].ID != obj.fusionCard.ID;
    }

    private bool IsMaxLevel(int i, FusionStartMessage obj){
        return (playerCardTeam[i].Rarity == Rarity.Legendary && playerCardTeam[i].Level == 10) || (obj.fusionCard.Rarity == Rarity.Legendary && obj.fusionCard.Level == 10);
    }
}
