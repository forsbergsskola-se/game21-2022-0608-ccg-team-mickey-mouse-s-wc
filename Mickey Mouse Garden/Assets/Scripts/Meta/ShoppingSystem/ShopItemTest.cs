using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game Objects/Shop Item",order = 0)]

public class ShopItemTest : ScriptableObject{
    public string name = "Default";
    public string description = "Description";
    public int money;
    public int fertilizer;
    public ObjectType type;
    public Sprite icon;
    
    #region Getters and Setters
    public string Name {
        get { return name; }
        set { name = value; }
    }
    public string Description {
        get { return description; }
        set { description = value; }
    }
    public int Money {
        get { return money; }
        set { money = value; }
    }
    public int Fertilizer {
        get { return fertilizer; }
        set { fertilizer = value; }
    }
    public ObjectType Type {
        get { return type; }
        set { type = value; }
    }
    public Sprite Icon {
        get { return icon; }
        set { icon = value; }
    }
    #endregion
    

}




public enum ObjectType{
    CommonSeed,
    RareSeed,
    EpicSeed,
    LegendarySeed,
    Song,
}

