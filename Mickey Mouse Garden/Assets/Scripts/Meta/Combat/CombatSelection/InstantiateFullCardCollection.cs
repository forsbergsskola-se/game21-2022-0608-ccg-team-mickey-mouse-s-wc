using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InstantiateFullCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private void OnEnable(){
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        for (int i = 0; i < playerCardTeam.Count; i++){
            var instance = Instantiate(cardButtonPrefab, gameObject.transform);
            instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
        }
    }
    private void OnDisable(){
        var cards = GetComponentsInChildren<CardView>();
        foreach (var card in cards){
            Destroy(card.gameObject);
        }
    }
}
