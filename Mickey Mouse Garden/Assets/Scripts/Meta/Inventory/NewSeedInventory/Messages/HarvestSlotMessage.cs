namespace Meta.Inventory.NewSeedInventory.Messages {
    public class HarvestSlotMessage : IMessage {
        public GrowSlot GrowSlot;

        public HarvestSlotMessage(GrowSlot growSlot) {
            GrowSlot = growSlot;
        }
    }
}