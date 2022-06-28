namespace Meta.Inventory.NewSeedInventory.Messages {
    public class GrowSlotReadyToHarvestMessage : IMessage {
        public NewGrowSlot GrowSlot;

        public GrowSlotReadyToHarvestMessage(NewGrowSlot growSlot) {
            GrowSlot = growSlot;
        }
    }
}