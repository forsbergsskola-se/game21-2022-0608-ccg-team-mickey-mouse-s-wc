using System.Collections.Generic;
using Meta.Inventory.SeedInventory;

namespace Meta.Messages.PlantMessages {
    public class UpdateSeedUi : IMessage {
        public UpdateSeedUi(List<Seed> seeds) { }
    }
}
