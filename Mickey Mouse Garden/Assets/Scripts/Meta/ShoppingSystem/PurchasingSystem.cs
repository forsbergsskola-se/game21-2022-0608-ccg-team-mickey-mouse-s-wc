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
    
    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }

    public void SetCurrency(DisplayPlayerCurrencyMessage displayPlayerCurrencyMessage){
        PlayerMoney = displayPlayerCurrencyMessage.money;
        PlayerFertilizer = displayPlayerCurrencyMessage.fertilizer;
    }


    #region MyRegion

    public void BuyItemWithMoney(ShopItemTest SO){
        if (PlayerMoney.Amount >= SO.money){
            PlayerMoney.Amount -= SO.money;
            var message = new AddPlayerCurrencyMessage();
            message.money = PlayerMoney;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
            NewSeed seed = new NewSeed();
            seed.rarity = SO.rarity;
            var collectedMessage = new ItemCollectedMessage<NewSeed>(seed);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);}
        
    }
    public void BuyItemWithFertilizer(ShopItemTest SO){
        if (PlayerFertilizer.Amount >= SO.fertilizer){
            PlayerFertilizer.Amount -= SO.fertilizer;
            var message = new AddPlayerCurrencyMessage();
            message.fertilizer = PlayerFertilizer;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
            NewSeed seed = new NewSeed();
            seed.rarity = SO.rarity;
            var collectedMessage = new ItemCollectedMessage<NewSeed>(seed);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
        }
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
    
    public void BuyLimitedItemWithMoney(int value){
        if (PlayerMoney.Amount >= value && !alreadyPurchased){
            PlayerMoney.Amount -= value;
            var message = new AddPlayerCurrencyMessage();
            message.money = PlayerMoney;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
        }
    }
    
    public void BuyLimitedItemWithMoneyAndFertilizer(int value, int value2){
        if (PlayerMoney.Amount < value || PlayerFertilizer.Amount < value2) return;
        PlayerMoney.Amount -= value;
        PlayerFertilizer.Amount -= value2;
        var message = new AddPlayerCurrencyMessage();
        message.money = PlayerMoney;
        message.fertilizer = PlayerFertilizer;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
    }

    #endregion
    

    
}