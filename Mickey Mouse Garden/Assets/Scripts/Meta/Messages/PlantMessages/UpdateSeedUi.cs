using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using Meta.Inventory.NewSeedInventory;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateSeedUi : IMessage
{
    public List<Seed> Seeds;
    
    public UpdateSeedUi(List<Seed> seeds)
    {
        this.Seeds = seeds;
    }
}
