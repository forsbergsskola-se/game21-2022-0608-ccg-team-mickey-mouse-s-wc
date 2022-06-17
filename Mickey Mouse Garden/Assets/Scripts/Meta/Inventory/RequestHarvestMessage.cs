namespace Meta.Inventory {
    public class RequestHarvestMessage : IMessage {
        public GrowSlot GrowSlot;
        
        public RequestHarvestMessage(GrowSlot growSlot) {
            GrowSlot = growSlot;
        }
    }
}