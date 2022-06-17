using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class OwnedCard : ISaveData{
     public int InstanceID{ get; set; } //TODO: 
     public string Name{ get; set; }
      public Alignment Alignment{ get; set; }
     public string SpriteName{ get; set; }
     public Sprite FighterImage{ get; set; } //TODO: Sprite or image?
     public Rarity Rarity{ get; set; }
    public short Level{ get; set; }
    public float Attack{ get; set; }
    public float MaxHealth{ get; set; }
    public float Speed{ get; set; }
     public int id;
    public int ID{
        get => id;
        set{ id = value; }
    }
    public async Task TryLoadData(){
        var card = await SaveManager.Load<OwnedCard>(id);
        InstanceID = card.InstanceID;
        Name = card.Name;
        Alignment = card.Alignment;
        SpriteName = card.SpriteName;
        FighterImage = Resources.Load<Sprite>($"Art/Sprites/{card.SpriteName}");
        Rarity = card.Rarity;
        Level = card.Level;
        Attack = card.Attack;
        MaxHealth = card.MaxHealth;
        Speed = card.Speed;
        ID = card.ID;
        
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public OwnedCard(int id, Rarity rarity, short level, float attack, float maxHealth, float speed){
        ID = id;
        Rarity = rarity;
        Level = level;
        Attack = attack;
        MaxHealth = maxHealth;
        Speed = speed;
    }

    public OwnedCard(){
        InstanceID = default; //TODO: Ideally not string for performance, GUID, but also want to show the designers...
   Name= default;
   Alignment= default;
    FighterImage= default;//TODO: Sprite or image?
    Rarity= default;
     Level= default;
     Attack= default;
     MaxHealth= default;
     Speed = default;
    }
}

