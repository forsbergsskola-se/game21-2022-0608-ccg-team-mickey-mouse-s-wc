using System;
using System.Collections;
using Meta.Interfaces;
using Meta.Inventory;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UDP;

public class PurchasingSystem : MonoBehaviour{

    
    private ShopItemList shopItems;
    //public string Name{ get; }

    public int PlayerMoney{ get; private set; } = 10000;
    public int PlayerFertilizer{ get; private set; } = 10000;

    //public string SpriteName{ get; }
    //public Sprite Sprite{ get; }
    public void BuySeedWithMoney(int value){
        if (PlayerMoney >= value){
            PlayerMoney -= value;
        }
    }
    public void BuySeedWithFertilizer(int value){
        if (PlayerFertilizer >= value){
            PlayerFertilizer -= value;
        }
    }
    
    public void BuySeedWithMoneyAndFertilizer(int value, int value2){
        if (PlayerMoney < value || PlayerFertilizer < value2) return;
        PlayerMoney -= value;
        PlayerFertilizer -= value2;
    }
    
    public void BuyMusicWithFertilizer(int value){
        if (PlayerFertilizer >= value){
            PlayerFertilizer -= value;
        }
    }
    
    public void BuyMusicWithMoney(int value){
        if (PlayerMoney >= value){
            PlayerMoney -= value;
        }
    }
    
    public void BuyMusicWithMoneyAndFertilizer(int value, int value2){
        if (PlayerMoney < value || PlayerFertilizer < value2) return;
        PlayerMoney -= value;
        PlayerFertilizer -= value2;
    }
    

    
}