using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;

public abstract class ShopItemConfig : ItemConfig{
    public bool isPurchased;
    public int moneyCost;
    public int fertilizerCost;
    public Sprite sprite;
}
    