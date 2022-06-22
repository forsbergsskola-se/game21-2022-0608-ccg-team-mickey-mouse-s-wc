using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class PlayerWallet : ISaveData
{
    public List<ICurrency> Currencies{ get; set; }
    public PlayerWallet(List<ICurrency> currencies){
        Currencies = currencies;
        TryLoadData();
    }
    public StringGUID ID{ get; }
    
    public async void TryLoadData(){
        var loadedValue = await SaveManager.Load<PlayerWallet>(ID);
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