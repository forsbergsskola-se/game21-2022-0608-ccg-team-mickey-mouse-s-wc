using System;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class CompleteFusionButton : MonoBehaviour
{
    private Card card1;
    private Card card2;
    

    private void OnEnable(){
        Broker.Subscribe<FusionStartMessage>(OnFusionStartMessageReceived);
        Broker.Subscribe<FusionEndMessage>(OnFusionEndMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<FusionStartMessage>(OnFusionStartMessageReceived);
        Broker.Unsubscribe<FusionEndMessage>(OnFusionEndMessageReceived);
    }

    private void OnFusionStartMessageReceived(FusionStartMessage obj){
        card1 = obj.fusionCard;
    }
    
    private void OnFusionEndMessageReceived(FusionEndMessage obj){
        card2 = obj.fusionCard;
    }
    
    public void OnClick(){
        var cardSacrificedMessage = new CardSacrificedMessage{Card1 = card1, Card2 = card2};
        Broker.InvokeSubscribers(typeof(CardSacrificedMessage), cardSacrificedMessage);
    }
}