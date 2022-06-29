using System.Collections;
using System.Collections.Generic;
using FMOD;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Thread = System.Threading.Thread;

public class Slot : MonoBehaviour{
    
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
        /*if (PlayerMoney.Amount < SO.money || PlayerFertilizer.Amount < SO.fertilizer) return;
        var message = new AddPlayerCurrencyMessage();
        message.money = new Money();
        message.money.Amount = -SO.money;
        message.fertilizer = new Fertilizer();
        message.fertilizer.Amount = -SO.fertilizer;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage),message);
        NewSeed seed = new NewSeed();
        seed.rarity = SO.rarity;
        RequestCurrency();
        var collectedMessage = new ItemCollectedMessage<NewSeed>(seed);
        Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);*/

    }

    private void ChangeTextToOutOfStock(){
        itemName.text = "Out of Stock";
    }

    private void ChangeTextToNotEnoughCurrency(){
        itemName.text = "Not Enough Currency";
        Thread.Sleep(1000);
        itemName.text = SlotData.item.Name;
    } 
}
