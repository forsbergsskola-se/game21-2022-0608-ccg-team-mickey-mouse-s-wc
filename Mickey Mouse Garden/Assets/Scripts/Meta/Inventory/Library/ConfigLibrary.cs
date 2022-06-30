
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfigLibrary<T> : ScriptableObject where T: ShopItemConfig{ // Possibly want to move things out of ShopItemConfig into ItemConfig.
    Dictionary<string, T> itemConfigs = new Dictionary<string, T>();

    public virtual T GetItem(string itemID){
        return itemConfigs[itemID];
    }

    public void AddItemConfig(T itemConfig){
        if(itemConfigs.ContainsKey(itemConfig.configID)){
            Debug.LogError("Trying to add an item to the library that already exists. ItemID: " + itemConfig.configID);
            return;
        }
        itemConfigs.Add(itemConfig.configID, itemConfig);
        Debug.Log($"Added item config to {GetType().Name}: " + itemConfig.configID);
    }
}
