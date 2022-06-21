using System.Threading.Tasks;
using UnityEngine;

public class CombatController : MonoBehaviour{
   [SerializeField] private FighterInfo[] playerFighters;
   [SerializeField] private FighterInfo[] enemyFighters;

   private FighterInfo playerFighter;
   private FighterInfo enemyFighter;
   private int playerTeamIncrementor;
   private int enemyTeamIncrementor;

   private bool playerGoesFirst;
   
   private Executor executor;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
      Broker.Subscribe<FighterFaintMessage>(OnDeathMessageRecieved);
      //playerFighter = playerFighters[playerTeamIncrementor];
      //enemyFighter = enemyFighters[enemyTeamIncrementor];
   }
   

   private void Update(){
      if (Input.GetKeyDown(KeyCode.P)){
         playerFighter = playerFighters[playerTeamIncrementor];
         enemyFighter = enemyFighters[enemyTeamIncrementor];
         Strike();
      }
   }

   private void Strike(){
      if (playerGoesFirst){
         executor.Enqueue(new StrikeCommand(enemyFighter, playerFighter));
         executor.Enqueue(new CheckForFaintedCommand(enemyFighter));
         playerGoesFirst = false;
      }
      else{
         executor.Enqueue(new StrikeCommand(playerFighter, enemyFighter));
         executor.Enqueue(new CheckForFaintedCommand(playerFighter));
         playerGoesFirst = true;
      }
   }

   private void OnDeathMessageRecieved(FighterFaintMessage obj){
      Debug.Log($"{obj.fighterInfo.Name} has died");
      if (obj.fighterInfo.ID == playerFighter.ID){
         
      }
      if (obj.fighterInfo.ID == enemyFighter.ID){
         
      }
      executor.Enqueue(new ChangeOpponentCommand());
      AssertStrikeOrder();

   }

   private void AssertStrikeOrder(){
      if (playerFighter.Speed < enemyFighter.Speed){
         playerGoesFirst = false;
      }
      else if (playerFighter.Speed > enemyFighter.Speed){
         playerGoesFirst = true;
      }
      else{
         var coinFlip = Random.Range(0, 2);
         if (coinFlip == 1){
            playerGoesFirst = true;
         }
      }
   }
}
