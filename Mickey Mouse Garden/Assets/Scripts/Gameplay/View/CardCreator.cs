using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    public Transform parent;
    private FighterInfo fighter;
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighter = obj.fighterInfo;
        InstantiateFighter(fighter);
    }

    private void InstantiateFighter(FighterInfo fighter){
        var createdCard = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, parent);
        var componentInChildren = createdCard.GetComponentInChildren<CardContentFiller>();
        var fighterInfo = createdCard.AddComponent<FighterInfo>();
        FillInInfo(fighterInfo);
        componentInChildren.AssignTextFields(fighter);
    }

    private void FillInInfo(FighterInfo fighterInfo){
        fighterInfo.Alignment = fighter.Alignment;
        fighterInfo.Attack = fighter.Attack;
        fighterInfo.Level = fighter.Level;
        fighterInfo.Name = fighter.Name;
        fighterInfo.Rarity = fighter.Rarity;
        fighterInfo.Speed = fighter.Speed;
        fighterInfo.Sprite = fighter.Sprite;
        fighterInfo.ID = fighter.ID;
        fighterInfo.MaxHealth = fighter.MaxHealth;

    }

    private void OnDestroy(){
        Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
    }
}
