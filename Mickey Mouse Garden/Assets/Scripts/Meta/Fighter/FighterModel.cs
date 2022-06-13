using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Fighter Model", menuName = "Fighter/Fighter Model")]
public class FighterModel : ScriptableObject,ISaveData
{
    [Header("Displayable Information")]
    public string name;
    public Alignment alignment;
    public Rarity rarity;
    [Min(1)]public int level;
    [Min(0)]public float attack;
    [Min(1)]public float maxHealth;
    [Min(1)]public float speed;
    public Image fighterImage; //TODO: Sprite or image?
    public Guid ID{ get; } = Guid.NewGuid();
    
}
