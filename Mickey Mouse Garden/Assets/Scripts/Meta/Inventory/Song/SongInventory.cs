using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using UnityEngine;
[Serializable]
public class SongInventory : Inventory<Song>
{
    public override InventoryList<Song> InventoryList{ get; set; }

    public override void CollectOperations(Song addedItem){
        throw new System.NotImplementedException();
    }

    public override void RemoveOperations(Song removedItem){
        throw new NotImplementedException();
    }
}
