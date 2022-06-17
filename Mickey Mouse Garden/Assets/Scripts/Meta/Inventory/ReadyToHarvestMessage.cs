using UnityEngine;

namespace Meta.Inventory {
    public class ReadyToHarvestMessage : IMessage {
        public GrowSlot HarvestableGrowSlot;
        public ReadyToHarvestMessage(GrowSlot harvestableGrowSlot) {
            HarvestableGrowSlot = harvestableGrowSlot;
        }
    }
}