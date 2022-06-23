using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemTest : MonoBehaviour{
    private float money = 10;
    public void ShopItemTestClick(){
        money -= 1;
        Debug.Log("Item Sold");
    }
}
