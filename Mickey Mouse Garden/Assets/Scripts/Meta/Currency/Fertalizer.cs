using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[Serializable]
public class Fertalizer : ICurrency, ISaveData
{
    public Fertalizer(){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
    }

    public string Name{ get; }
    public int Amount{ get; private set; }
    public string SpriteName{ get; } = "Fertalizer";

    public Sprite Sprite{ get; }

    public void AddAmount(int value){
        Amount += value;
    }
    public StringGUID ID{ get; }
    
    public Task TryLoadData(){
        throw new System.NotImplementedException();
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
