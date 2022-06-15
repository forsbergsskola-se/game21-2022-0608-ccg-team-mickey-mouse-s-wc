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

   [ContextMenu("Test")]
   void Test(){
      var saveMessage = new SaveMessage(FighterModel);
         Debug.Log("Invoking Test");
         Broker.InvokeSubscribers(saveMessage.GetType(),saveMessage); //Implement at better place
      FighterModel.alignment = Alignment.Rock;
   }
}
