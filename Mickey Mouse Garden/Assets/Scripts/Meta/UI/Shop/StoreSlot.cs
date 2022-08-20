using Meta.Currency;
using Meta.Inventory.SeedInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

public class StoreSlot : MonoBehaviour{
    public PlayerWalletSO playerWalletSo;
    public ShopItemConfig shopItemConfig;
    public Player player;
    public SeedInventory seedInventory;
    
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemMoneyPrice;
    public TextMeshProUGUI itemFertilizerPrice;
    public Image image;
    public bool usedForSelling;

    void Awake(){
        itemName.text = shopItemConfig.name;
        image.sprite = shopItemConfig.sprite;
        
        if(usedForSelling){
            itemMoneyPrice.text = shopItemConfig.moneySellAmount.ToString();
            itemFertilizerPrice.text = shopItemConfig.fertilizerSellAmount.ToString();
        }
        else{
            itemMoneyPrice.text = shopItemConfig.moneyPurchaseAmount.ToString();
            itemFertilizerPrice.text = shopItemConfig.fertilizerPurchaseAmount.ToString();
        }
        player=FindObjectOfType<Player>();
    }
    

    void Start(){
        if (shopItemConfig.itemAmount <= 0){
            ChangeTextToOutOfStock();
        }
    }

    void OnEnable(){
        RequestCurrency();
    }

    public void ButtonInteraction(){
        if (usedForSelling){
            SellItem();
        }
    }

    private void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }
    public async void BuyWithMoney(){
        RequestCurrency();
        if (shopItemConfig.itemAmount <= 0){
            ChangeTextToOutOfStock();
            return;
        }
        if (playerWalletSo.playerWallet.Money.Amount < shopItemConfig.moneyPurchaseAmount){
            await TemporarilyChangeSlotName("Not enough Money");
            return;
        }
        if (shopItemConfig.moneyPurchaseAmount<=0){
            await TemporarilyChangeSlotName("Can not buy with Money");
            return;
        }
        SendAddPlayerCurrencyMessage(-shopItemConfig.moneyPurchaseAmount,0);
        
        if (!shopItemConfig.isUnlimited){
            shopItemConfig.itemAmount--;
        }
        
        shopItemConfig.SendCreateItemMessage(shopItemConfig.libraryID);
    }
    public async void BuyWithFertilizer(){
        RequestCurrency();
        if (shopItemConfig.itemAmount <= 0){
            ChangeTextToOutOfStock();
            return;
        }
        
        if (playerWalletSo.playerWallet.Fertilizer.Amount < shopItemConfig.fertilizerPurchaseAmount){
            await TemporarilyChangeSlotName("Not enough Fertilizer");
            return;
        }
        if (shopItemConfig.fertilizerPurchaseAmount<=0){
            await TemporarilyChangeSlotName("Can not buy with Fertilizer");
            return;
        }
        SendAddPlayerCurrencyMessage(0,-shopItemConfig.fertilizerPurchaseAmount);
        
        if (!shopItemConfig.isUnlimited){
            shopItemConfig.itemAmount--;
        }
        shopItemConfig.SendCreateItemMessage(shopItemConfig.libraryID);
    }

    public async void SellItem(){

        if (seedInventory == null){
            seedInventory = player.GetComponent<SeedInventory>();
        }
        
        var seedInInventory = seedInventory.InventoryList.Items.Find(x => x.libraryID == shopItemConfig.libraryID);

        if (seedInInventory==null){
            await TemporarilyChangeSlotName("Not enough seeds");
            return;
        }
        shopItemConfig.SendRemoveItemMessage(shopItemConfig.libraryID);
        SendAddPlayerCurrencyMessage(shopItemConfig.moneySellAmount,shopItemConfig.fertilizerSellAmount); 
    }
    
    

    private void SendAddPlayerCurrencyMessage(int moneyAmount, int fertilizerAmount){
        var message = new AddPlayerCurrencyMessage();
        message.money = new Money(){
            Amount = moneyAmount
        };
        message.fertilizer = new Fertilizer(){
            Amount = fertilizerAmount
        };
        message.Invoke();
    }

    private void ChangeTextToOutOfStock(){
        itemName.text = "Out of Stock";
    }

    private async Task TemporarilyChangeSlotName(string tempText){
        itemName.text = tempText;
        await Task.Delay(400);
        itemName.text = shopItemConfig.name; //Probably not the right Name.
    } 
}