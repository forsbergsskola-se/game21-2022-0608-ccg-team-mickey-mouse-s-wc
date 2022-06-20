using System;
using UnityEngine;

public class StrikeCommand : ICommand{
   private GameObject target;
   private GameObject striker;

   public StrikeCommand(GameObject target, GameObject striker){
      this.target = target;
      this.striker = striker;
   }
   public void Execute(){
      Debug.Log($"{striker} hit {target}");
   }

   public void Undo(){
      throw new NotImplementedException();
   }
}

public class CombatController : MonoBehaviour{
   private GameObject[] playerFighters;
   private GameObject[] enemyFighters;

   [SerializeField] private GameObject activeFighter;
   [SerializeField] private GameObject opposingFighter;

   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
   }

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         Debug.Log("Testing combat");
         executor.Enqueue(new StrikeCommand(activeFighter, opposingFighter));
      }
   }
}
