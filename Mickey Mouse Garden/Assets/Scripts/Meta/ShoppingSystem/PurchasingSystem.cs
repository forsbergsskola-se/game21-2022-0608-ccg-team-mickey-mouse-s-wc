using System.Collections;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEditor;
using UnityEngine;
using UnityEngine.UDP;

public class PurchasingSystem<T> : MonoBehaviour where T : IInventoryItem{
    public Inventory<T> Inventory;
    private ShopItemList shopItems;
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