using System;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

namespace Meta.Currency{
    [Serializable][JsonObject]
    public class Fertilizer : ICurrency
    {
        public string Name{ get; } = "Fertilizer";
        public int Amount{ get; set; }
        public string SpriteName{ get; } = "Fertilizer";

        [field: NonSerialized][DoNotSerialize]public Sprite Sprite{ get; set; }

        public void AddAmount(int value){
            Amount += value;
        }
    
        public void LoadSprite(){
            Sprite = Resources.Load<Sprite>($"Art/Sprites/{this.SpriteName}");
        }
    }
}
