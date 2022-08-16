using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    
    private string Fertilizerx10 = "10xFertilizer";
    private string Fertilizerx60 = "60xFertilizer";
    private string Fertilizerx120 = "120xFertilizer";
    private string Fertilizerx650 = "650xFertilizer";
    

    public void OnPurchaseComplete(Product product){
        var reward = new Fertilizer();
        if (product.definition.id == Fertilizerx10){
            reward.Amount = 10;
        }
        if (product.definition.id == Fertilizerx60){
            reward.Amount = 60;
        }
        if (product.definition.id == Fertilizerx120){
            reward.Amount = 120;
        }
        if (product.definition.id == Fertilizerx650){
            reward.Amount = 650;
        }
        Debug.Log(reward.Amount);
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), new AddPlayerCurrencyMessage{fertilizer = reward});
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason){
        Debug.Log(product.definition.id + " failed to purchase because " + reason);
    }
}
