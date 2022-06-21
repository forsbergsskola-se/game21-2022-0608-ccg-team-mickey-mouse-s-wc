using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UDP;

public abstract class Item: IInventoryItem
{
    public string ItemName{ get; set; }
    public int Price{ get; }

    public Item(int price, string name){
        this.Price = price;
        this.ItemName = name;
    }
    
}