using System;
using System.Threading.Tasks;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
[Serializable]
public record OwnedCard : ISaveData{
    readonly Card Card;
    public Rarity Rarity;
    [Min(1)]public int Level;
    [Min(0)]public float Attack;
    [Min(1)]public float MaxHealth;
    [Min(1)]public float Speed;
    public Guid ID{ get; }
    public Task TryLoadData(){
        throw new NotImplementedException(); // This probably will never be called.
    }

    public void Save(){
        throw new NotImplementedException(); //TODO: Implement Save, should be called whenever card gets changed.
    }

    public OwnedCard(Guid id, Card card, Rarity rarity, int level, float attack, float maxHealth, float speed){
        ID = id;
        Card = card;
        Rarity = rarity;
        Level = level;
        Attack = attack;
        MaxHealth = maxHealth;
        Speed = speed;
    }
}

