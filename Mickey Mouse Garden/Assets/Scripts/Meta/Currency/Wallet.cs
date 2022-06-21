using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class Wallet: ISaveData{
    public Dictionary<StringGUID,ICurrency> Currencies{ get; set; }
    public StringGUID ID{ get; }

    public Wallet(Dictionary<StringGUID,ICurrency> currencies ){
        Currencies = currencies;
        foreach (var currencyPair in Currencies){
            currencyPair.Value.TryLoadData();
        }
    }
    public async Task TryLoadData(){
        var loadedValue = await SaveManager.Load<Money>(ID);
        var loadedPropertyInfos = loadedValue.GetType().GetProperties();
        var gottenType = GetType();
        var propertyInfos =gottenType.GetProperties();
        
        for (int i = 0; i < propertyInfos.Length; i++){
            gottenType.GetProperty(propertyInfos[i].Name)?.SetValue(this,loadedPropertyInfos[i].GetValue(loadedValue));
        }
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
