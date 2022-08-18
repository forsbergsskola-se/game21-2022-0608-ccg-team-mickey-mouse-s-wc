using Meta.Inventory.FighterInventory;

namespace Meta.Cards{
    public class EnterLevelMessage : IMessage{
        public int Level { get; set; }
        public Money Reward { get; set; }
        public CardConfig[] CardConfigTeam{ get; set; }
    }
    
}