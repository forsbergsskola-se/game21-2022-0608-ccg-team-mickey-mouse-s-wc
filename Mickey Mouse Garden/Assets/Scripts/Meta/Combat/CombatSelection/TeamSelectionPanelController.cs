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
        // Prevent duplicate cards from being selected.
        foreach (var cardView in playercards){
            if (cardView.id == newCardSelectedMessage.Card.ID){
                Debug.Log("Same ID");
                return;
            }
        }
        newCard = newCardSelectedMessage.Card;
        SwapCards();
    }

    public void SwapCards() {
        originCard = newCard;
        playercards[position].Configure(originCard);
    }
    public void Back(){
        GetComponent<Canvas>().enabled = false;
        UILockMessage uiLockMessage = new(){
            Locked = false
        };
        Broker.InvokeSubscribers(typeof(UILockMessage), uiLockMessage);
    }
}
