using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game Objects/Shop Item",order = 0)]

public class ShopItemTest : ScriptableObject{
    public string Name = "Default";
    public string description = "Description";
    public ICurrency[] Cost;
    public ObjectType type;
    public Sprite icon;
    public GameObject prefab;
}


public enum ObjectType{
    CommonSeed,
    RareSeed,
    EpicSeed,
    LegendarySeed,
    Song,
}

