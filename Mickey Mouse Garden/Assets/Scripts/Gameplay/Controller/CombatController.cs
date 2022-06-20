using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeCommand : ICommand{
   public void Execute(){
      Debug.Log("hit");
   }

   public void Undo(){
      throw new NotImplementedException();
   }
}

public class CombatController : MonoBehaviour{
   private GameObject[] playerFighters;
   private GameObject[] enemyFighters;

   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
   }

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         Debug.Log("Testing combat");
         executor.Enqueue(new StrikeCommand());
      }
   }
}
