using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InstantiateFullCardCollection : MonoBehaviour{
    [SerializeField] private GameObject cardButtonPrefab;
    private List<Card> playerCardTeam;
    private Card originCard;
    private void OnEnable(){
        Broker.Subscribe<CardSelectionMessage>(OnCardSelectionMessageReceived);
        playerCardTeam = FindObjectOfType<CardInventory>().InventoryList.Items;
        StartCoroutine(DisplayValidCards());
    }
    private IEnumerator DisplayValidCards(){
        yield return new WaitForSeconds(0.1f);
        foreach (var card in playerCardTeam){
            if (card.ID != originCard.ID){
                var instance = Instantiate(cardButtonPrefab, gameObject.transform);
                instance.GetComponentInChildren<CardView>().Configure(card);
            }
        }
    }
    private void OnCardSelectionMessageReceived(CardSelectionMessage obj){
        originCard = obj.Card;
    }
    private void OnDisable(){
        var cards = GetComponentsInChildren<CardView>();
        foreach (var card in cards){
            Destroy(card.gameObject);
        }
    }
}
