using Meta.Cards;

public class CardSelectionMessage : IMessage{
    public CardConfig SentCardConfig{get; set; }
    public int Position{ get; set; }
    public bool SelectionPanelActive{ get; set; }
}
