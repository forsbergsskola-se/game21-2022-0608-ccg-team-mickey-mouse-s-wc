namespace Meta.Inventory.NewSeedInventory.Messages {
    public class GrowSlotReadyToHarvestMessage : IMessage {
        public NewGrowSlotPrefabs GrowSlotPrefabs;

        public GrowSlotReadyToHarvestMessage(NewGrowSlotPrefabs growSlotPrefabs) {
            GrowSlotPrefabs = growSlotPrefabs;
        }
    }
}