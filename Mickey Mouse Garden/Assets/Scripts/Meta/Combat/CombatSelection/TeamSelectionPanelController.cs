using Meta.Cards;
using UnityEngine;

public class TeamSelectionPanelController : MonoBehaviour {
    private CardConfig originCard;
    private CardConfig newCard;

    private int position;

    [SerializeField] private CardView[] playercards;
    
    private void Start() {
        Broker.Subscribe<CardSelectionMessage>(StoreOriginCard);
        Broker.Subscribe<NewCardSelectedMessage>(StoreNewCard);
    }

    private void StoreOriginCard(CardSelectionMessage cardSelectionMessage) {
        originCard = cardSelectionMessage.CardConfig;
        position = cardSelectionMessage.Position;
    }

    private void StoreNewCard(NewCardSelectedMessage newCardSelectedMessage) {
        newCard = newCardSelectedMessage.CardConfig;
        SwapCards();
    }

    public void SwapCards() {
        originCard = newCard;
        playercards[position].Configure(originCard);
    }
}
