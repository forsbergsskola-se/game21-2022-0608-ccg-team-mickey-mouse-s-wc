using Meta.Cards;
using UnityEngine;

public class TeamSelectionPanelController : MonoBehaviour {
    private CardConfig originCard;
    private CardConfig newCard;
    
    private void Start() {
        Broker.Subscribe<CardSelectionMessage>(StoreOriginCard);
        Broker.Subscribe<NewCardSelectedMessage>(StoreNewCard);
    }

    private void StoreOriginCard(CardSelectionMessage cardSelectionMessage) {
        originCard = cardSelectionMessage.CardConfig;
        Debug.Log(originCard.name);
    }

    private void StoreNewCard(NewCardSelectedMessage newCardSelectedMessage) {
        newCard = newCardSelectedMessage.CardConfig;
        Debug.Log(newCard.name);
    }

    public void SwapCards() {
        originCard = newCard;
    }
}
