using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : ISaveData{
    int level;
    public int Level{
        get => level;
        set{
            level = value;
            Save();
        }
    }

    internal PlayerLevel(){
        TryLoadData();
    }
    public StringGUID ID{ get; }
    public void TryLoadData(){
        Level = SaveManager.Load<PlayerLevel>(ID).Result.Level;
    }

    public void Save(){
        SaveManager.Save(this);
    }
}