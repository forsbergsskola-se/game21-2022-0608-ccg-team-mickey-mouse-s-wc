namespace Meta.Cards {
    public class NewCardSelectedMessage : IMessage {
        public CardConfig CardConfig {get; set; }
    }
}