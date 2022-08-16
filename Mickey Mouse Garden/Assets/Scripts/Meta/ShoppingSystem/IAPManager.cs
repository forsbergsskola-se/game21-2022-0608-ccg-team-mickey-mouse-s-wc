using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    
    private string fertilizer_10 = "fertilizer_10";
    private string fertilizer_60 = "fertilizer_60";
    private string fertilizer_120 = "fertilizer_120";
    private string fertilizer_650 = "fertilizer_650";
    

    public void OnPurchaseComplete(Product product){
        var reward = new Fertilizer();
        if (product.definition.id == fertilizer_10){
            reward.Amount = 10;
        }
        if (product.definition.id == fertilizer_60){
            reward.Amount = 60;
        }
        if (product.definition.id == fertilizer_120){
            reward.Amount = 120;
        }
        if (product.definition.id == fertilizer_650){
            reward.Amount = 650;
        }
        Debug.Log(reward.Amount);
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), new AddPlayerCurrencyMessage{fertilizer = reward});
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason){
        Debug.Log(product.definition.id + " failed to purchase because " + reason);
    }
}
