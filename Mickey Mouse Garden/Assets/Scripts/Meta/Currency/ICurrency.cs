using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrency : ISaveData
{
   public string Name{ get; }
   public int Amount{ get; }
   public string SpriteName{ get; }
   public Sprite Sprite{ get;  } 
   public void AddAmount(int value);
  
}
