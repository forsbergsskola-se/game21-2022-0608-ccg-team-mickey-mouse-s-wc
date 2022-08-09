using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InstantiateFullCardCollection : MonoBehaviour{ //TODO: combine with SpawnCardButtons if time and energy.
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private void Awake(){
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        for (int i = 0; i < playerCardTeam.Count; i++){
            var instance = Instantiate(cardButtonPrefab, gameObject.transform);
            instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
        }
    }
}
