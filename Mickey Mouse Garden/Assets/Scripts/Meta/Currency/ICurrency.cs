using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrency
{
   public string Name{ get; }
   public int Amount{ get; }
   public string SpriteName{ get; }
   Sprite Sprite{ get;  } 
   public void AddAmount(int value);
  
}
