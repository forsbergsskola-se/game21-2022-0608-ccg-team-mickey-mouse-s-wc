using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using UnityEngine;

public class SongInventory : Inventory<Song>
{
    public override List<Song> Items{ get; set; }
    public override void CollectOperations(Song addedItem){
        throw new System.NotImplementedException();
    }
}
