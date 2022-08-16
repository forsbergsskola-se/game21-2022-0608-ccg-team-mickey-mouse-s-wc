using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    
    private string Fertilizerx10 = "10xFertilizer";

    public void OnPurchaseComplete(Product product){
        if (product.definition.id == Fertilizerx10){
            //do something
            Debug.Log("You have purchased 10x fertilizer");
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason){
        Debug.Log(product.definition.id + " failed to purchase because " + reason);
    }
}
