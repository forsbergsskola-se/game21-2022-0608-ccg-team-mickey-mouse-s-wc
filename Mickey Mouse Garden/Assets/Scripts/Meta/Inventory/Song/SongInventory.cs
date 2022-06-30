using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using UnityEngine;
[Serializable]
public class SongInventory : Inventory<Song>{
    public override InventoryList<Song> InventoryList{ get; set; } =
        new InventoryList<Song>(new StringGUID().CreateStringGuid(40404));
}
