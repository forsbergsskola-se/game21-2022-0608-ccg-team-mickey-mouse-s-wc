using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[Serializable][JsonObject]
public class SlotData: ISaveData{
    public bool isPurchased;
    public Item item;

    public StringGUID ID{ get; }
    public int Money{ get; }
    public int Fertilizer{ get; }


    public void TryLoadData(){
        SaveManager.Load<SlotData>(ID);
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
