using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song Config", menuName = "Configs/Song")]
public class SongConfig : ShopItemConfig{
    string theme = "MetaMusic";
    public int parameter;

   // public override ConfigLibrary<ShopItemConfig> ConfigLibrary{ get; set; }

    public override void SendCreateItemMessage(string pathID){
        var message = new CreateNewInventoryItemMessage<Song>(pathID);
        Broker.InvokeSubscribers(message.GetType(), message);
    }
}
