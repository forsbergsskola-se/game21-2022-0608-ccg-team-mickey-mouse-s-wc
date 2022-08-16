using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public static T GetRandom<T>(this InventoryList<T> list) where T : IInventoryItem
    {
        int randomIndex = Random.Range(0, list.Items.Count);
        return list.Items[randomIndex];
    }
    
    public static void Invoke(this IMessage message)
    {
        Broker.InvokeSubscribers(message.GetType(), message);
    }
    
    public static void CopyAllValuesFrom<T>(this T source, T itemToCopyFrom) where T : class {
        var sourceProperties = typeof(T).GetProperties().Where(x=> x.Name != "ID").ToList();
        var itemToCopyFromProperties = typeof(T).GetProperties().Where(x=> x.Name != "ID").ToList();

        var sourceFields = typeof(T).GetFields();
        var itemToCopyFromFields = typeof(T).GetFields();

        //Copies all the Properties
        foreach (var sourceProperty in sourceProperties){
            foreach (var itemToCopyFromProperty in itemToCopyFromProperties){
                if (sourceProperty.Name == itemToCopyFromProperty.Name){
                    sourceProperty.SetValue(source, itemToCopyFromProperty.GetValue(itemToCopyFrom));
                }
            }
        }
        //Copies all the Fields
        foreach (var sourceField in sourceFields){
            foreach (var itemToCopyFromField in itemToCopyFromFields){
                if (sourceField.Name == itemToCopyFromField.Name){
                    sourceField.SetValue(source, itemToCopyFromField.GetValue(itemToCopyFrom));
                }
            }
        }
    }
}
