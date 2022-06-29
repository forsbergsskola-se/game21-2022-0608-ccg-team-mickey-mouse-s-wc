using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using Meta.Inventory.NewSeedInventory;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateSeedUi : IMessage
{
    public InventoryList<NewSeed> Seeds;
    
    public UpdateSeedUi(InventoryList<NewSeed> seeds)
    {
        this.Seeds = seeds;
    }
}
