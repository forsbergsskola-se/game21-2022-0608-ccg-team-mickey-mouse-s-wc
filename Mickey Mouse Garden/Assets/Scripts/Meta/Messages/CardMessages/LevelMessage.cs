using Meta.Inventory.FighterInventory;

namespace Meta.Cards{
    public class LevelMessage : IMessage{
        public Card[] Team { get; set; }
        public CardConfig[] CardConfigTeam{ get; set; }
        public Money Reward { get; set; }
        public int Level { get; set; }

    }
}