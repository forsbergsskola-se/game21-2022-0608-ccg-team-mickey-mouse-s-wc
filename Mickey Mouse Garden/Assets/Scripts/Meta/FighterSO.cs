using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Fighter", menuName = "Fighter/Fighter Data")]
public class FighterSO : ScriptableObject{
    [Header("Displayable Information")]
    public string Name;
    public FamilyType Type;
    public Rarity Rarity;
    [Min(0)]public int Level;
    [Min(0)]public float Attack;
    [Min(0)]public float MaxHealth;
    public Image FighterImage; //TODO: Sprite or image?
}
