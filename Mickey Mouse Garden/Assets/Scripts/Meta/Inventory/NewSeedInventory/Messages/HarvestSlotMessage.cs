namespace Meta.Inventory.NewSeedInventory.Messages {
    public class HarvestSlotMessage : IMessage {
        public NewGrowSlotPrefabs GrowSlotPrefabs;

        public HarvestSlotMessage(NewGrowSlotPrefabs growSlotPrefabs) {
            GrowSlotPrefabs = growSlotPrefabs;
        }
    }
}