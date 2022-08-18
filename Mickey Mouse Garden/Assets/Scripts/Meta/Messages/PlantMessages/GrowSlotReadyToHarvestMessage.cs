namespace Meta.Inventory.NewSeedInventory.Messages {
    public class GrowSlotReadyToHarvestMessage : IMessage {
        public GrowSlot GrowSlot;

        public GrowSlotReadyToHarvestMessage(GrowSlot growSlot) {
            GrowSlot = growSlot;
        }
    }
}