using System.Collections;
using System.Collections.Generic;
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
    }

    private void StoreNewCard(NewCardSelectedMessage newCardSelectedMessage) {
        newCard = newCardSelectedMessage.CardConfig;
    }

    public void SwapCards() {
        originCard = newCard;
    }
}
