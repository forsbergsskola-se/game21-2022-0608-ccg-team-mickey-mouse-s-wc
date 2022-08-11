using System;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class CompleteFusionButton : MonoBehaviour
{
    private Card card1;
    private Card card2;

    private void OnEnable(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
        Broker.Subscribe<FusionStartMessage>(OnFusionStartMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
        Broker.Unsubscribe<FusionStartMessage>(OnFusionStartMessageReceived);    }

    private void OnFusionStartMessageReceived(FusionStartMessage obj){
        card2 = obj.fusionCard;
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        card1 = obj.card;
    }
    

    public void OnClick(){
        var cardSacrificedMessage = new CardSacrificedMessage{Card1 = card1, Card2 = card2};
        Broker.InvokeSubscribers(typeof(CardSacrificedMessage), cardSacrificedMessage);
        Debug.Log(card1.ID);
        Debug.Log(card2.ID);
    }
}
