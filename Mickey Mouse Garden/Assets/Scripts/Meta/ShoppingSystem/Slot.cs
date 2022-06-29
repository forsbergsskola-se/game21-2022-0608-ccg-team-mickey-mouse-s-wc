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

public class Slot : MonoBehaviour{
    public PlayerWalletSO playerWalletSo;
    public SlotData SlotData;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemPrice;
    [SerializeField]
    private Image itemImage;
    



    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }
    public void BuyItem(){
        if (SlotData.isPurchased){
            ChangeTextToOutOfStock();
            return;
        }
        RequestCurrency();
        if (playerWalletSo.playerWallet.Money.Amount < SlotData.Money || playerWalletSo.playerWallet.Fertilizer.Amount < SlotData.Fertilizer){
            ChangeTextToNotEnoughCurrency();
            return;
        }
        SendAddPlayerCurrencyMessage();
        SendAddItemToInventoryMessage();
    }

    void SendAddItemToInventoryMessage(){
        var message = new AddItemToInventoryMessage<IInventoryItem>(SlotData.item,1);
        Broker.InvokeSubscribers(message.GetType(), message);
    }

    void SendAddPlayerCurrencyMessage(){
        var message = new AddPlayerCurrencyMessage();
        message.money = new Money();
        message.money.Amount = -SlotData.Money;
        message.fertilizer = new Fertilizer();
        message.fertilizer.Amount = -SlotData.Fertilizer;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
    }

    private void ChangeTextToOutOfStock(){
        itemName.text = "Out of Stock";
    }

    private void ChangeTextToNotEnoughCurrency(){
        itemName.text = "Not Enough Currency";
        Thread.Sleep(1000);
        //itemName.text = SlotData.ID;
    } 
}
