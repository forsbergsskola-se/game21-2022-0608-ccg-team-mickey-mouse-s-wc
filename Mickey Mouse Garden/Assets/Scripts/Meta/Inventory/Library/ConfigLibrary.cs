
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfigLibrary<T> : ScriptableObject where T: ItemConfig{ // Possibly want to move things out of ShopItemConfig into ItemConfig.
    public abstract Dictionary<string, T> itemConfigs{ get; set; }

    public virtual T GetItem(string itemID){
        return itemConfigs[itemID];
    }

    public void AddItemConfig(T itemConfig){
        if(itemConfigs.ContainsKey(itemConfig.libraryID)){
            Debug.LogError("Trying to add an item to the library that already exists. ItemID: " + itemConfig.libraryID);
            return;
        }
        itemConfigs.Add(itemConfig.libraryID, itemConfig);
    }
}
