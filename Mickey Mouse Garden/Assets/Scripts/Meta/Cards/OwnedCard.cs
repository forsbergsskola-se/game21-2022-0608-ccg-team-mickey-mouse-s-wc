using System;
using Meta.Interfaces;
using UnityEngine;

[Serializable]
public class OwnedCard : ISaveData, IInventoryItem { // This class will be saved, Treat is as a scriptable object and dont change these values after creation. Create your copy
     public StringGUID ID{
            get;
            set;
     }
     public string libraryID{ get; set; }
    public string Name{ get; set; }
    public Alignment Alignment{ get; set; }
    public string SpriteName{ get; set; }
    public Sprite FighterImage{ get; private set; } //TODO: Sprite or Image? //TODO: Change to Texture 2D?
    public Rarity Rarity{ get; set; }
    public short Level{ get; set; }
    public float Attack{ get; set; }
    public float MaxHealth{ get; set; }
    public float Speed{ get; set; }
   

    public OwnedCard(StringGUID stringGuid,string name, Alignment alignment, string spriteName, Rarity rarity, short level, float attack, float maxHealth, float speed){
        ID = stringGuid;
        Name = name;
        Alignment = alignment;
        SpriteName = spriteName;
        Rarity = rarity;
        Level = level;
        Attack = attack;
        MaxHealth = maxHealth;
        Speed = speed;
        Save();
    }
    public OwnedCard(){
        ID = default;
        Name = default;
        Alignment = default;
        SpriteName = default;
        Rarity = default;
        Level = default;
        Attack = default;
        MaxHealth = default;
        Speed = default;
    }
    
    public async void TryLoadData(){
        var card = await SaveManager.Load<OwnedCard>(ID);
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

    
}