using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    private FighterInfo fighter;
    private Transform[] cardSlots;
    [HideInInspector] public int cardCount = 1;
    private void Awake(){
        Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterMessageReceived);
        // Gets cardSlots from Child GameObjects
        cardSlots = GetComponentsInChildren<Transform>();
    }

    private void OnFighterMessageReceived(SelectedFighterTeamMessage obj){
        FighterInfo[] cards = new FighterInfo[3];
        obj.FighterTeam.CopyTo(cards,0);
        for (int i = cards.Length - 1; i >= 0; i--){
            Debug.Log(i);
            fighter = cards[i];
            // Spawns card at incremental card slots starting from 1 (not 0).
            InstantiateFighter(fighter, cardSlots[cardCount]);
            cardCount++;
        }
    }

    private void InstantiateFighter(FighterInfo fighter, Transform cardSlot){
        var createdCard = Instantiate(card, cardSlot.position, Quaternion.identity, cardSlots[0]); //TODO: What does the 0 mean?
        var componentInChildren = createdCard.GetComponentInChildren<CardContentFiller>();
        var fighterInfo = new FighterInfo();
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
        fighterInfo.SpriteIndex = fighter.SpriteIndex;
        fighterInfo.ID = fighter.ID;
        fighterInfo.MaxHealth = fighter.MaxHealth;

    }

    private void OnDestroy(){
        Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterMessageReceived);
    }
}
