
using Meta.Currency;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;
using Thread = System.Threading.Thread;

public class StoreSlot : MonoBehaviour{
    public PlayerWalletSO playerWalletSo;
    public ShopItemConfig shopItemConfig;
    
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemMoneyPrice;
    public TextMeshProUGUI itemFertilizerPrice;
    public Image image;


    void Awake(){
        itemName.text = shopItemConfig.name;
        image.sprite = shopItemConfig.sprite;
        itemMoneyPrice.text = shopItemConfig.moneyCost.ToString();
        itemFertilizerPrice.text = shopItemConfig.fertilizerCost.ToString();
    }

    void Start(){
        RequestCurrency();
        if (shopItemConfig.isPurchased){
            ChangeTextToOutOfStock();
        }
    }

    public void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }
    /// <summary>
    ///    Called when the player clicks on the slot. If the player has enough currency, the item is purchased.
    /// </summary>
    public async void BuyItem(){
        if (shopItemConfig.isPurchased){
            ChangeTextToOutOfStock();
            return;
        }
        
        if (playerWalletSo.playerWallet.Money.Amount < shopItemConfig.moneyCost || playerWalletSo.playerWallet.Fertilizer.Amount < shopItemConfig.fertilizerCost){
            await ChangeTextToNotEnoughCurrency();
            return;
        }
        RequestCurrency();
        SendAddPlayerCurrencyMessage();
        shopItemConfig.SendCreateItemMessage(shopItemConfig.configID);
    }
    void SendAddPlayerCurrencyMessage(){
        var message = new AddPlayerCurrencyMessage();
        message.money = new Money();
        message.money.Amount = -shopItemConfig.moneyCost;
        message.fertilizer = new Fertilizer();
        message.fertilizer.Amount = -shopItemConfig.fertilizerCost;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
    }

    private void ChangeTextToOutOfStock(){
        itemName.text = "Out of Stock";
    }

    private async Task ChangeTextToNotEnoughCurrency(){
        itemName.text = "Not Enough Currency";
        await Task.Delay(1000);
        itemName.text = shopItemConfig.name; //Probably not the right name.
    } 
}