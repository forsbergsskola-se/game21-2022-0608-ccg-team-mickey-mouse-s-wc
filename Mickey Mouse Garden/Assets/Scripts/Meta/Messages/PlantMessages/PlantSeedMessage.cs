namespace Meta.Inventory {
    public class PlantSeedMessage : IMessage {
        public Rarity SeedRarity;

        public PlantSeedMessage(Rarity rarity) {
            SeedRarity = rarity;
        }
    }
}