
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfigLibrary<T> : ScriptableObject where T: ItemConfig{ // Possibly want to move things out of ShopItemConfig into ItemConfig.
    public abstract List<T> itemConfigs{ get; set; }

    public virtual T GetItem(short itemID){
        return itemConfigs[itemID];
    }

    void Awake(){
        ClearLibrary();
    }

    public void AddItemConfigToLibrary(T itemConfig){
        if (itemConfigs.Contains(itemConfig)){
            return;
        }

        var newLibraryID = itemConfigs.Count;
        itemConfig.libraryID = (short)newLibraryID;
        
        itemConfigs.Add(itemConfig);
        Debug.Log("Added item to library. LibraryID: " + itemConfig.libraryID);
    }
    
    [ContextMenu("Clear Library")]
    void ClearLibrary(){
        itemConfigs.Clear();
    }
}
