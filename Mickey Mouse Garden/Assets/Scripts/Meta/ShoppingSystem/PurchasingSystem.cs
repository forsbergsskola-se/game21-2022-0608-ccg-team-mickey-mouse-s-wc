using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEditor;
using UnityEngine;
using UnityEngine.UDP;

public class PurchasingSystem<T> : MonoBehaviour, ICurrency where T : IInventoryItem{
    public Inventory<T> Inventory;
    private object shopItems;
    public string Name{ get; }

    public int Amount{ get; private set; }

    public string SpriteName{ get; }
    public Sprite Sprite{ get; }
    public void AddAmount(int value){
        throw new System.NotImplementedException();
    }

    public void BuyFromShop(Item item){
        if (Amount - item.price < 0)
        {
            return;
        }

        Amount -= item.price;
        RemoveItemFromList(shopItems, item);
        //.Add(item);
    }

    private void RemoveItemFromList(object shopItems, Item item){
        throw new System.NotImplementedException();
    }
}

public class Item{
    public int price;

    public Item(int price){
        this.price = price;
    }
}
