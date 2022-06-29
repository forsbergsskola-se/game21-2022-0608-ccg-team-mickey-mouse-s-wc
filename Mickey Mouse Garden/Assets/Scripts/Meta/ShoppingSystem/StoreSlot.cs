using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using Meta.Currency;
using Meta.Interfaces;
using Meta.Inventory;
using Meta.Inventory.NewSeedInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Thread = System.Threading.Thread;

public class StoreSlot : MonoBehaviour{
    public PlayerWalletSO playerWalletSo;
    public ShopItemConfig shopItemConfig;
    
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemMoneyPrice;
    public TextMeshProUGUI itemFertilizerPrice;
    public Image image;


    void Awake(){
        // image = GetComponent<Image>();
    }

    void Start(){
        image.sprite = shopItemConfig.sprite;
        itemMoneyPrice.text = shopItemConfig.moneyCost.ToString();
        itemFertilizerPrice.text = shopItemConfig.fertilizerCost.ToString();
    }

    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }
    public void BuyItem(){
        if (shopItemConfig.isPurchased){
            ChangeTextToOutOfStock();
            return;
        }
        RequestCurrency();
        if (playerWalletSo.playerWallet.Money.Amount < shopItemConfig.moneyCost || playerWalletSo.playerWallet.Fertilizer.Amount < shopItemConfig.fertilizerCost){
            ChangeTextToNotEnoughCurrency();
            return;
        }
       //SendAddPlayerCurrencyMessage();
        //SendAddItemToInventoryMessage();
    }

    // void SendAddItemToInventoryMessage(){
    //     var message = new AddItemToInventoryMessage<IInventoryItem>(SlotData.item,1);
    //     Broker.InvokeSubscribers(message.GetType(), message);
    // }

    // void SendAddPlayerCurrencyMessage(){
    //     var message = new AddPlayerCurrencyMessage();
    //     message.money = new Money();
    //     message.money.Amount = -SlotData.Money;
    //     message.fertilizer = new Fertilizer();
    //     message.fertilizer.Amount = -SlotData.Fertilizer;
    //     Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
    // }

    private void ChangeTextToOutOfStock(){
        itemName.text = "Out of Stock";
    }

    private void ChangeTextToNotEnoughCurrency(){
        itemName.text = "Not Enough Currency";
        Thread.Sleep(1000);
        //itemName.text = SlotData.ID;
    } 
}
