using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterInfo {
    public int ID { get; private set;}
    public float MaxHealth { get; private set;}
    public float Attack { get; private set;}
    public float Speed { get; private set;}
    public int Level  { get; private set;}
    public string Rarity  { get; private set;}
    public string Name { get; private set;}
    public Alignment Alignment { get; private set;}
    public Sprite Sprite { get; private set;}
}
