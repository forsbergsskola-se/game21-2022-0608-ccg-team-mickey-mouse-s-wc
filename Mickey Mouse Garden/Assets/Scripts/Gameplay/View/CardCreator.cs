using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    private FighterInfo fighter;
    private List<FighterInfo> fighters = new List<FighterInfo>();
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighter = obj.fighterInfo;
        fighters.Add(fighter);
    }

    private void InstantiateAllFightersGathered(){
        foreach (var fighter in fighters){
            Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
            var componentInChildren = card.GetComponentInChildren<CardContentFiller>();
            componentInChildren.Name = fighter.Name;
            componentInChildren.ID = fighter.ID;
            componentInChildren.MaxHealth = fighter.MaxHealth;
            componentInChildren.Attack = fighter.Attack;
            componentInChildren.Speed = fighter.Speed;
            componentInChildren.Level = fighter.Level;
            componentInChildren.Rarity = fighter.Rarity;
            componentInChildren.Name = fighter.Name;
            componentInChildren.Alignment = fighter.Alignment;
            componentInChildren.Sprite = fighter.Sprite;
        }
    }
    
    private void OnDestroy(){
        Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
    }
}
