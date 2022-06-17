using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour{
   public FighterModel fighterModel;
   public  FighterModel FighterModel{ // Possibly redundant if this doesnt work
      get => fighterModel;
      set{
         fighterModel = value;
         //Invoke call - Probably doesnt work
      }
   }
}
