using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class Fertalizer : ICurrency
{
    public Fertalizer(){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
    }

    public string Name{ get; } = "Fertalizer";
    public int Amount{ get; private set; }
    public string SpriteName{ get; } = "Fertalizer";

    public Sprite Sprite{ get; }

    public void AddAmount(int value){
        Amount += value;
    }

    public StringGUID ID{ get; }
    public async Task TryLoadData(){
        var loadedValue = await SaveManager.Load<Money>(ID);
        var loadedPropertyInfos = loadedValue.GetType().GetProperties();
        var propertyInfos =GetType().GetProperties();
        for (int i = 0; i < propertyInfos.Length; i++){
            GetType().GetProperty(propertyInfos[i].Name)?.SetValue(this,loadedPropertyInfos[i].GetValue(loadedValue));
        }
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
