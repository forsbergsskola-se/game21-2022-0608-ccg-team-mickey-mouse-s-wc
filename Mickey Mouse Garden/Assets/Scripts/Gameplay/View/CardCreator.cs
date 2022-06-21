using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    public Transform parent;
    private FighterInfo fighter;
    private Transform[] cardSlots;
    public int cardCount = 1;
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
        // Gets cardSlots from Child GameObjects
        cardSlots = GetComponentsInChildren<Transform>();
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighter = obj.fighterInfo;
        // Spawns card at incremental card slots starting from 1 (not 0).
        InstantiateFighter(fighter, cardSlots[cardCount]);
        cardCount++;
    }

    private void InstantiateFighter(FighterInfo fighter, Transform cardSlot){
        var createdCard = Instantiate(card, cardSlot.position, Quaternion.identity, parent);
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
