using TMPro;
using UnityEngine;

public class SeedStoreList : MonoBehaviour{ 
    public ShopItemTest commonSeed;
    public ShopItemTest rareSeed;
    public ShopItemTest epicSeed;
    public ShopItemTest legendarySeed;
    [SerializeField] 
    private TextMeshProUGUI commonSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI rareSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI epicSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI legendarySeedPriceText;

    private void Awake(){
        commonSeedPriceText.text = commonSeed.money.ToString() + " $";
        rareSeedPriceText.text = rareSeed.money.ToString() + " $";
        epicSeedPriceText.text = epicSeed.fertilizer.ToString() + " pc";
        legendarySeedPriceText.text = legendarySeed.fertilizer.ToString() + " pc";
    }
    //TODO: Make Items display multiple currency types
}
