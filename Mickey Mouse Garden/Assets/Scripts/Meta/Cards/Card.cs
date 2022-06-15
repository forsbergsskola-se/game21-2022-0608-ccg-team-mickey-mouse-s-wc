using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject{
   public string ID;
   public string Name;
   public Alignment Alignment;
   public Image FighterImage; //TODO: Sprite or image?
}
