using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public record FighterMessage : IMessage{ //TODO: make sure its the correct types.
   private int id, health, damage, speed, level;
   private string rarity, name, alignment;
   private Sprite sprite;
}
