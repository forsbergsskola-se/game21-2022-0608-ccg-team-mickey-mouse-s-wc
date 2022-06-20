using UnityEngine;

public class CombatController : MonoBehaviour{
   private GameObject[] playerFighters;
   private GameObject[] enemyFighters;

   [SerializeField] private FighterInfo activeFighter;
   [SerializeField] private FighterInfo opposingFighter;

   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
   }

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         executor.Enqueue(new StrikeCommand(activeFighter, opposingFighter));
      }
   }
}
