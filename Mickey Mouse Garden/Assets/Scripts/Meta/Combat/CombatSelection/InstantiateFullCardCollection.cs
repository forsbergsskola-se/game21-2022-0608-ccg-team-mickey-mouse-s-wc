using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InstantiateFullCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private void OnEnable(){
        Broker.Subscribe<SortCardInventoryByRarityMessage>(OnSortCardInventoryByRarityMessageReceived);
        Broker.Subscribe<SortCardInventoryByAlignmentMessage>(OnSortCardInventoryByAlignmentMessageReceived);
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        for (int i = 0; i < playerCardTeam.Count; i++){
            var instance = Instantiate(cardButtonPrefab, gameObject.transform);
            instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
        }
    }

    void OnSortCardInventoryByAlignmentMessageReceived(SortCardInventoryByAlignmentMessage obj){
        OnDisable();
        OnEnable();
    }

    void OnSortCardInventoryByRarityMessageReceived(SortCardInventoryByRarityMessage obj){
        OnDisable();
        OnEnable();
    }

    private void OnDisable(){
        Broker.Unsubscribe<SortCardInventoryByRarityMessage>(OnSortCardInventoryByRarityMessageReceived);
        Broker.Unsubscribe<SortCardInventoryByAlignmentMessage>(OnSortCardInventoryByAlignmentMessageReceived);
        var cards = GetComponentsInChildren<CardView>();
        foreach (var card in cards){
            Destroy(card.gameObject);
        }
    }
}
