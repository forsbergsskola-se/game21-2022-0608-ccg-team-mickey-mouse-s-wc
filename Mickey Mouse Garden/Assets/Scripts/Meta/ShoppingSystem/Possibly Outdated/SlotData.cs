using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

[Serializable][JsonObject]
public class SlotData: ISaveData{
    public bool isPurchased{ get; set; }
    public IInventoryItem item;

    [NonSerialized]public string Name;
    public StringGUID ID{ get; }
    [NonSerialized] public int Money;
    [NonSerialized] public int Fertilizer;


    public void TryLoadData(){
        SaveManager.Load<SlotData>(ID);
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
