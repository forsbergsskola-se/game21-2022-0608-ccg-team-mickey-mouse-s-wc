using System;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class FusionButton : MonoBehaviour{
    private Card card;

    private void Awake(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        card = obj.card;
    }

    public void OnClick(){
        var fusionStartMessage = new FusionStartMessage {fusionCard = card}; 
        Broker.InvokeSubscribers(typeof(FusionStartMessage), fusionStartMessage);
    }
}