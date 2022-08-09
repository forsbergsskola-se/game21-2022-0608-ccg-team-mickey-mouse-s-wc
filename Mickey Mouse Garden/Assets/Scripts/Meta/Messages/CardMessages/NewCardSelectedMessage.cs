using Meta.Inventory.FighterInventory;

namespace Meta.Cards {
    public class NewCardSelectedMessage : IMessage {
        public Card Card {get; set; }
    }
}