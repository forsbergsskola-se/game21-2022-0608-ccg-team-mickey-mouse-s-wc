using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CombatController : MonoBehaviour{
   [SerializeField] private FighterInfo[] playerFighters;
   [SerializeField] private FighterInfo[] enemyFighters;

   [SerializeField] private int duration;

   private FighterInfo playerFighter;
   private FighterInfo enemyFighter;
   
   private int playerTeamIncrementor;
   private int enemyTeamIncrementor;
   private bool playerGoesFirst;
   
   private Executor executor;
   private Timer timer;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
      Broker.Subscribe<FighterFaintMessage>(OnDeathMessageRecieved);
      timer = new Timer(Tick, null, 1000* duration,1000* duration);
   }
   
   private void Tick(object state){
      Strike();
   }
   private void Update(){
      if (Input.GetKeyDown(KeyCode.O)){ //this will be done automatically in the end, for now stage by pressing O
         playerFighter = playerFighters[playerTeamIncrementor];
         enemyFighter = enemyFighters[enemyTeamIncrementor]; 
      }
   }

   private void Strike(){
      if (playerGoesFirst){
         executor.Enqueue(new StrikeCommand(enemyFighter, playerFighter));
         executor.Enqueue(new CheckForFaintedCommand(playerFighter, enemyFighter));
         playerGoesFirst = false;
      }
      else{
         executor.Enqueue(new StrikeCommand(playerFighter, enemyFighter));
         executor.Enqueue(new CheckForFaintedCommand(playerFighter, enemyFighter));
         playerGoesFirst = true;
      }
   }

   private void OnDeathMessageRecieved(FighterFaintMessage obj){
      Debug.Log($"{obj.fighterInfo.Name} has died");
      if (obj.wasPlayerFighter){
         playerTeamIncrementor++;
      }
      else{
         enemyTeamIncrementor++;
      }
      if (playerTeamIncrementor > 2 || enemyTeamIncrementor > 2){
         timer.Dispose();
         executor.Enqueue(new EndOfCombatCommand(playerTeamIncrementor, enemyTeamIncrementor, new Money()));  
      }
      executor.Enqueue(new ChangeOpponentCommand(this));
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

   public void NextFighter(){
      playerFighter = playerFighters[playerTeamIncrementor];
      enemyFighter = enemyFighters[enemyTeamIncrementor];
   }
}