namespace Meta.Cards {
    public class SpawnCardFromSeed : IMessage {
        public Rarity Rarity;

        public SpawnCardFromSeed(Rarity rarity) {
            Rarity = rarity;
        }
    }
}