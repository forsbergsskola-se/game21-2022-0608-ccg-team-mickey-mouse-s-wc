using Meta.Cards;

public class CardSelectionMessage : IMessage{
    public CardConfig CardConfig{get; set; }
    public int Position{ get; set; }
}
