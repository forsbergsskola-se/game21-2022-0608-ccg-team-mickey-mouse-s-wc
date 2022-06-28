using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
[Serializable][JsonObject]
public class Money : ICurrency
{
    public string Name{ get; } = "Money";
    public int Amount{ get; set; }
    public string SpriteName{ get; } = "Money";

    [DoNotSerialize] public Sprite Sprite{ get; set; }

    public void AddAmount(int value){
        Amount += value;
    }

    public void LoadSprite(){
        Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
    }
}
