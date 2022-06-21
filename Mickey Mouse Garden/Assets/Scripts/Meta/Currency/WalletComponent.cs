using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletComponent : MonoBehaviour{
    public Wallet wallet;

    void Start(){
        var Money = new Money(new StringGUID("12345678-1111-4f21-b3c1-b017dce032e0"));
        var Fertilizer = new Fertilizer(new StringGUID("12345678-2222-4f21-b3c1-b017dce032e0"));
        Dictionary<StringGUID, ICurrency> currencies = new Dictionary<StringGUID, ICurrency>();
        currencies.Add(Money.ID,Money);
        currencies.Add(Fertilizer.ID,Fertilizer);
        
        wallet = new Wallet(currencies);
    }
}
