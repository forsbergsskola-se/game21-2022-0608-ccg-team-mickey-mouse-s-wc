using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrency : ISaveData
{
   public string Name{ get; }
   public int Amount{ get; }
   public string SpriteName{ get; }
   [field: NonSerialized]Sprite Sprite{ get;  } 
   public void AddAmount(int value);
  
}
