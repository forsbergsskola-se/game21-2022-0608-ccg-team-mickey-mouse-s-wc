using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject{
   public string ID; //TODO: Ideally not string for performance, GUID, but also want to show the designers...
   public string Name;
   public Alignment Alignment;
   public Sprite FighterImage; //TODO: Sprite or image?
}
