using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;

public abstract class ShopItemConfig : ItemConfig{
    public bool isUnlimited = true;
    public int itemAmount = 1;
    [Min(0)]public int moneyPurchaseAmount;
    public int moneySellAmount;
    public int fertilizerPurchaseAmount;
    public int fertilizerSellAmount;
    public Sprite sprite;
}
    