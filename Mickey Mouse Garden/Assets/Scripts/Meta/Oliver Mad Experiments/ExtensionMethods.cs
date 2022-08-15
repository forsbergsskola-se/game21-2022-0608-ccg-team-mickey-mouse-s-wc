using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

public static class ExtensionMethods
{
    public static T GetRandom<T>(this List<T> list)
    {
        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
    public static T GetRandom<T>(this InventoryList<T> list)
        where T : IInventoryItem
    {
        int randomIndex = Random.Range(0, list.Items.Count);
        return list.Items[randomIndex];
    }
    
    public static void Invoke(this IMessage message)
    {
        Broker.InvokeSubscribers(message.GetType(), message);
    }
}
