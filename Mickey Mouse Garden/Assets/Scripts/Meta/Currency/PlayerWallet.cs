using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class PlayerWallet : ISaveData
{
    public Money Money { get; set; }
    public Fertilizer Fertilizer { get; set; }
    public PlayerWallet( StringGUID id){
        Money = new Money();
        Fertilizer = new Fertilizer();
        ID = id;
    }
    
    public StringGUID ID{ get; }
    
    public async void TryLoadData(){
        var loadedValue = await SaveManager.Load<PlayerWallet>(ID);
        if (loadedValue == null){
            return;
        }
        var loadedPropertyInfos = loadedValue.GetType().GetProperties().Where(x => x.Name != "ID").ToArray();
        var gottenType = GetType();
        var propertyInfos =gottenType.GetProperties().Where(x => x.Name != "ID").ToArray();
        
        for (int i = 0; i < propertyInfos.Length; i++){
            gottenType.GetProperty(propertyInfos[i].Name)?.SetValue(this,loadedPropertyInfos[i].GetValue(loadedValue));
        }
    }

    public void Save(){
        SaveManager.Save(this);
    }
}