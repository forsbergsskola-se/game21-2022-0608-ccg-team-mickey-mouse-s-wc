using System.Collections;
using System.Collections.Generic;
using Meta.Inventory.NewSeedInventory;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateSeedUi : IMessage
{
    public List<NewSeed> Seeds;
    
    public UpdateSeedUi(List<NewSeed> seeds)
    {
        this.Seeds = seeds;
    }
}
