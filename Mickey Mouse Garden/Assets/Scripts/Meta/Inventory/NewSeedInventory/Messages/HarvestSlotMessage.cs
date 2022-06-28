namespace Meta.Inventory.NewSeedInventory.Messages {
    public class HarvestSlotMessage : IMessage {
        public NewGrowSlot GrowSlot;

        public HarvestSlotMessage(NewGrowSlot growSlot) {
            GrowSlot = growSlot;
        }
    }
}