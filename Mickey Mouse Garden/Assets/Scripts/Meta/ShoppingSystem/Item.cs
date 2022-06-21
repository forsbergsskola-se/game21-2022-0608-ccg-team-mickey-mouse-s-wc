using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UDP;

public class Item: MonoBehaviour, IInventoryItem{
    public string itemName;
    public int price;

    public bool stackable;

    public Item(int price, string name){
        this.price = price;
        this.itemName = name;
    }
    
}