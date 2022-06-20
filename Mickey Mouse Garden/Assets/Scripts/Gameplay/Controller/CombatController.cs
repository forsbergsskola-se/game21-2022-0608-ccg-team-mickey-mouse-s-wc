using UnityEngine;

public class CombatController : MonoBehaviour{
   private GameObject[] playerFighters;
   private GameObject[] enemyFighters;

   [SerializeField] private FighterInfo firstFighter;
   [SerializeField] private FighterInfo secondFighter;

   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
   }

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         AssertStrikeOrder();
         executor.Enqueue(new StrikeCommand(secondFighter, firstFighter));
         Debug.Log($"I was hit!{secondFighter.Name}");
         Debug.Log($"I hit it! {firstFighter.Name}");
      }
   }

   private void AssertStrikeOrder(){
      if (firstFighter.Speed < secondFighter.Speed){
         (secondFighter, firstFighter) = (firstFighter, secondFighter);
      }
      else if (firstFighter.Speed > secondFighter.Speed){
         return;
      }
      else{
         var coinFlip = Random.Range(0, 2);
         if (coinFlip == 1){
            (secondFighter, firstFighter) = (firstFighter, secondFighter);
         }
      }
   }
}
