using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class Money : ICurrency
{
    public Money(){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
    }

    public string Name{ get; } = "Money";
    public int Amount{ get; private set; }
    public string SpriteName{ get; } = "Money";

    [field: NonSerialized][DoNotSerialize] public Sprite Sprite{ get; }

    public void AddAmount(int value){
        Amount += value;
    }
}
