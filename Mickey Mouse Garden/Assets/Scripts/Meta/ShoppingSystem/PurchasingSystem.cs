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

    private bool alreadyPurchased;
    
    
    private Money PlayerMoney{ get; set;}
    private Fertilizer PlayerFertilizer{ get; set;}
    

    private void Awake(){
        Broker.Subscribe<DisplayPlayerCurrencyMessage>(SetCurrency);

    }
    
    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }

    public void SetCurrency(DisplayPlayerCurrencyMessage displayPlayerCurrencyMessage){
        PlayerMoney = displayPlayerCurrencyMessage.money;
        PlayerFertilizer = displayPlayerCurrencyMessage.fertilizer;
    }
    

    public void BuyItemWithMoney(ShopItemTest SO){
        if (PlayerMoney.Amount >= SO.money){
            PlayerMoney.Amount -= SO.money;
        }
    }
    public void BuyItemWithFertilizer(ShopItemTest SO){
        if (PlayerFertilizer.Amount >= SO.fertilizer){
            PlayerFertilizer.Amount -= SO.fertilizer;
        }
    }
    
    public void BuyItemWithMoneyAndFertilizer(int value, int value2){
        if (PlayerMoney.Amount < value || PlayerFertilizer.Amount < value2) return;
        PlayerMoney.Amount -= value;
        PlayerFertilizer.Amount -= value2;
    }
    
    public void BuyLimitedItemWithFertilizer(int value){
        if (PlayerFertilizer.Amount >= value && !alreadyPurchased){
            PlayerFertilizer.Amount -= value;
        }
    }
    
    public void BuyLimitedItemWithMoney(int value){
        if (PlayerMoney.Amount >= value && !alreadyPurchased){
            PlayerMoney.Amount -= value;
        }
    }
    
    public void BuyLimitedItemWithMoneyAndFertilizer(int value, int value2){
        if (PlayerMoney.Amount < value || PlayerFertilizer.Amount < value2) return;
        PlayerMoney.Amount -= value;
        PlayerFertilizer.Amount -= value2;
    }
    

    
}