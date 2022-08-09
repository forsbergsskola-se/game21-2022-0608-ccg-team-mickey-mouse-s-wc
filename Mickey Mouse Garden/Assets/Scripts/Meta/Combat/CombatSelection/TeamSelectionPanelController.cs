using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class TeamSelectionPanelController : MonoBehaviour {
    private Card originCard;
    private Card newCard;

    private int position;

    [SerializeField] private CardView[] playercards;
    
    private void Start() {
        Broker.Subscribe<CardSelectionMessage>(StoreOriginCard);
        Broker.Subscribe<NewCardSelectedMessage>(StoreNewCard);
    }

    private void StoreOriginCard(CardSelectionMessage cardSelectionMessage) {
        originCard = cardSelectionMessage.Card;
        position = cardSelectionMessage.Position;
    }

    private void StoreNewCard(NewCardSelectedMessage newCardSelectedMessage) {
        newCard = newCardSelectedMessage.Card;
        SwapCards();
    }

    public void SwapCards() {
        originCard = newCard;
        playercards[position].Configure(originCard);
    }
}
