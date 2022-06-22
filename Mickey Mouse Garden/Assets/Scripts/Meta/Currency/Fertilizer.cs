using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class Fertilizer : ICurrency
{
    public Fertilizer(){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
    }

    public string Name{ get; } = "Fertilizer";
    public int Amount{ get; private set; }
    public string SpriteName{ get; } = "Fertilizer";

    [field: NonSerialized][DoNotSerialize]public Sprite Sprite{ get; }

    public void AddAmount(int value){
        Amount += value;
    }
}
