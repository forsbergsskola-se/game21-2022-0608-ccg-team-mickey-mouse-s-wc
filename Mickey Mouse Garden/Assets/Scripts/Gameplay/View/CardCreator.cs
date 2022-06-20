using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    public Transform parent;
    private FighterInfo fighter;
    private List<FighterInfo> fighters = new();
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighter = obj.fighterInfo;
        fighters.Add(fighter);
        InstantiateFighter(fighter);
    }

    private void InstantiateFighter(FighterInfo fighter){
        Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, parent);
        var componentInChildren = card.GetComponentInChildren<CardContentFiller>();
        componentInChildren.AssignTextFields(fighter);
    }

    private void OnDestroy(){
        Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
    }
}
