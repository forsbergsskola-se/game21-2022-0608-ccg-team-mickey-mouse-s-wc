namespace Meta.Cards{
    public class LevelMessage : IMessage{
        public CardConfig[] Team { get; set; }
        public int Reward { get; set; }
        public int Level { get; set; }

    }
}