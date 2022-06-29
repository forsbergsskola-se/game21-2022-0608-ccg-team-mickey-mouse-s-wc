using System;
using Meta.Interfaces;
using Meta.Seeds;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UDP;
[Serializable][JsonObject]
public class Item{
    public enum ItemType{
        Seed,
        Fertilizer,
        Song
    }

    public string Name{ get; set; }

    public static int GetCost(ItemType itemType){
        switch (itemType){
            default:
            case ItemType.Seed: return 10;
            case ItemType.Fertilizer: return 20;
            case ItemType.Song: return 30;
        }
    }

}