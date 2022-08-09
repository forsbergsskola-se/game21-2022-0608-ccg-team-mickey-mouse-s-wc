using Meta.Cards;
using Meta.Inventory.FighterInventory;

public class CardSelectionMessage : IMessage{
    public Card Card{get; set; }
    public int Position{ get; set; }
}
