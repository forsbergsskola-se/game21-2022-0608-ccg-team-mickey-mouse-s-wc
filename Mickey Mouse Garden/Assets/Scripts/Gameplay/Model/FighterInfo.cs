using UnityEngine;

public record FighterInfo {
    public int ID { get; set;}
    public float MaxHealth { get; set;}
    public float Attack { get; set;}
    public float Speed { get; set;}
    public int Level  { get; set;}
    public string Rarity  { get; set;}
    public string Name { get; set;}
    public Alignment Alignment { get; set;}
    public Sprite Sprite { get; set;}
}