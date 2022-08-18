using System;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class FusionButton : MonoBehaviour{
    private Card card;
    [SerializeField] private GameObject backButton;

    private void OnEnable(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        card = obj.card;
    }

    public void OnClick(){
        backButton.SetActive(true);
        var fusionStartMessage = new FusionStartMessage {fusionCard = card}; 
        Broker.InvokeSubscribers(typeof(FusionStartMessage), fusionStartMessage);
    }
}