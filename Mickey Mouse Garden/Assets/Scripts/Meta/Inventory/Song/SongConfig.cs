using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song Config", menuName = "Configs/Song")]
public class SongConfig : ShopItemConfig{
    string theme = "MetaMusic";
    public int parameter;

    public ConfigLibrary<SongConfig> library;
    

    void OnEnable(){
        TryAddToLibrary();
    }

    public override void SendCreateItemMessage(short LibraryID){
        Debug.Log("Invoking Seed Create Message" + " " + LibraryID);
        var message = new CreateNewInventoryItemMessage<Song>(LibraryID);
        Broker.InvokeSubscribers(message.GetType(), message);
    }

    public override void SendRemoveItemMessage(short LibraryID){
        Debug.Log("Invoking Seed Remove Message" + " " + LibraryID);
        var message = new RemoveInventoryItemMessage<Song>(LibraryID);
        Broker.InvokeSubscribers(message.GetType(), message);
    }

    public override void TryAddToLibrary(){
       library.AddItemConfigToLibrary(this);
   }
}
