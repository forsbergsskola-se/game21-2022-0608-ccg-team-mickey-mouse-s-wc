using System;
using System.Collections;
using Meta.Interfaces;
using Meta.Inventory;
using Meta.Inventory.NewSeedInventory;
using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
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

    void OnDisable(){
        Broker.Unsubscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
    }

    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }

    public void SetCurrency(DisplayPlayerCurrencyMessage displayPlayerCurrencyMessage){
        PlayerMoney = displayPlayerCurrencyMessage.money;
        PlayerFertilizer = displayPlayerCurrencyMessage.fertilizer;
    }


    #region Seeds

    public void BuyItem(ShopItemTest SO){
        RequestCurrency();
        if (PlayerMoney.Amount < SO.money || PlayerFertilizer.Amount < SO.fertilizer) return;
        PlayerMoney.Amount -= SO.money;
        PlayerFertilizer.Amount -= SO.fertilizer;
        var message = new AddPlayerCurrencyMessage();
        message.money = PlayerMoney;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
        NewSeed seed = new NewSeed();
        seed.rarity = SO.rarity;
        var collectedMessage = new ItemCollectedMessage<NewSeed>(seed);
        Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
    }
    #endregion

    
    
    #region limitedItems

    public void BuyLimitedItemWithFertilizer(int value){
        if (PlayerFertilizer.Amount >= value && !alreadyPurchased){
            PlayerFertilizer.Amount -= value;
            var message = new AddPlayerCurrencyMessage();
            message.fertilizer = PlayerFertilizer;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
            
        }
    }

    #endregion
    

    
}