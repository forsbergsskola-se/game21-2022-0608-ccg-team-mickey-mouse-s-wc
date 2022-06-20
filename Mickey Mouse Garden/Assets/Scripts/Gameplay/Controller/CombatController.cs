using UnityEngine;

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
