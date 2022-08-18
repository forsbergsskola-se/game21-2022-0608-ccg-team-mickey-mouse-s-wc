using Meta.Inventory.FighterInventory;

namespace Meta.Cards {
    public class CardAddedToInventoryMessage : IMessage {
        public Card Card;

        public CardAddedToInventoryMessage(Card card) {
            Card = card;
        }
    }
}