using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    private FighterInfo fighter;
    private Transform[] cardSlots;
    [HideInInspector] public int cardCount = 1;
    private const int ParentTransform = 0;

    private void Awake(){
        Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterMessageReceived);
        // Gets cardSlots from Child GameObjects
        cardSlots = GetComponentsInChildren<Transform>();
    }

    private void OnFighterMessageReceived(SelectedFighterTeamMessage obj){
        var cards = new FighterInfo[3];
        obj.FighterTeam.CopyTo(cards,0);
        for (var i = cards.Length - 1; i >= 0; i--){
            fighter = cards[i];
            // Spawns card at incremental card slots starting from 1 (not 0).
            InstantiateFighter(fighter, cardSlots[cardCount]);
            cardCount++;
        }
    }

    private void InstantiateFighter(FighterInfo fighter, Transform cardSlot){
        var createdCard = Instantiate(card, cardSlot.position, Quaternion.identity, cardSlots[ParentTransform]); 
        var componentInChildren = createdCard.GetComponentInChildren<CardContentFiller>();
        var fighterInfo = new FighterInfo();
        
        fighterInfo.CopyAllValuesFrom(fighter);
        
        componentInChildren.AssignTextFields(fighter);
    }
    private void OnDestroy(){
        Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterMessageReceived);
    }
}
