using System.Threading.Tasks;
using UnityEngine;

public class CombatController : MonoBehaviour{
   private FighterInfo[] playerFighters;
   private FighterInfo[] enemyFighters;

   [SerializeField] private FighterInfo firstFighter;
   [SerializeField] private FighterInfo secondFighter;

   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
      Broker.Subscribe<FighterFaintMessage>(OnDeathMessageRecieved);
   }
   

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         AssertStrikeOrder();
         executor.Enqueue(new StrikeCommand(secondFighter, firstFighter));
         executor.Enqueue(new CheckForFaintedCommand(firstFighter, secondFighter));
         executor.Enqueue(new StrikeCommand(firstFighter, secondFighter));
         executor.Enqueue(new CheckForFaintedCommand(secondFighter, firstFighter));
      }
   }
   
   private void OnDeathMessageRecieved(FighterFaintMessage obj){
      Debug.Log($"{obj.fighterInfo.Name} has died");
      executor.Enqueue(new ChangeOpponentCommand(out var newFighter)); 
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
