using System.Collections.Generic;

namespace Meta.Inventory.FighterInventory {
    public class FighterInventory : Inventory<OwnedCard> {
        public override List<OwnedCard> inventory { get; set; }
        
        
        
        
        public override void CollectOperations(OwnedCard objInventoryItem) {
            throw new System.NotImplementedException();
        }
    }
}