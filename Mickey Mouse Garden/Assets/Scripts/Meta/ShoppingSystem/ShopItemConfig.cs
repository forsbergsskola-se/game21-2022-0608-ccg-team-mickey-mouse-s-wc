using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;

public abstract class ShopItemConfig : ItemConfig{
    public string configID;
    public bool isPurchased;
    public int moneyCost;
    public int fertilizerCost;
    public Sprite sprite;
   // public abstract ConfigLibrary<ShopItemConfig> configLibrary;
    

    public abstract void SendCreateItemMessage(string pathID);
    
}
