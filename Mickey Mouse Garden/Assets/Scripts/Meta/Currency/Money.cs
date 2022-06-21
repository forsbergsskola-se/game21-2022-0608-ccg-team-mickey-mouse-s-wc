using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class Money : ICurrency
{
    public Money(StringGUID id){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
        ID = id;
    }

    public string Name{ get; } = "Money";
    public int Amount{ get; private set; }
    public string SpriteName{ get; } = "Money";

    [field: NonSerialized][DoNotSerialize] public Sprite Sprite{ get; }

    public void AddAmount(int value){
        Amount += value;
        Save();
    }

    public StringGUID ID{ get; }
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
