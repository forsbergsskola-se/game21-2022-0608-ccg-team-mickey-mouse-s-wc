using System.Collections.Generic;
using Meta.Inventory.SeedInventory;

public class UpdateSeedUi : IMessage
{
    public List<Seed> Seeds;
    
    public UpdateSeedUi(List<Seed> seeds)
    {
        this.Seeds = seeds;
    }
}
