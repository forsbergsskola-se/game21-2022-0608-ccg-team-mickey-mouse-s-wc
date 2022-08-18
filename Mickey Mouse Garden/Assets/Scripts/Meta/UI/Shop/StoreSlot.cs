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
        else{
            BuyItem();
        }
    }

    private void RequestCurrency(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }
    /// <summary>
    ///  Called when the player clicks on the slot. If the player has enough currency, the item is purchased.
    /// </summary>
    private async void BuyItem(){
        RequestCurrency();
        if (shopItemConfig.itemAmount <= 0){
            ChangeTextToOutOfStock();
            return;
        }
        
        if (playerWalletSo.playerWallet.Money.Amount < shopItemConfig.moneyPurchaseAmount || playerWalletSo.playerWallet.Fertilizer.Amount < shopItemConfig.fertilizerPurchaseAmount){
            await TemporarilyChangeSlotName("Not enough currency");
            return;
        }

        if (!shopItemConfig.isUnlimited){
            shopItemConfig.itemAmount--;
        }
        
        SendAddPlayerCurrencyMessage(-shopItemConfig.moneyPurchaseAmount,-shopItemConfig.fertilizerPurchaseAmount);
        
        shopItemConfig.SendCreateItemMessage(shopItemConfig.libraryID);
    }

    private async void SellItem(){

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
        message.money = new Money();
        message.money.Amount = moneyAmount;
        message.fertilizer = new Fertilizer();
        message.fertilizer.Amount = fertilizerAmount;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
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