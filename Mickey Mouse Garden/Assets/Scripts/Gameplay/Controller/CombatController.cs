using UnityEngine;
using Random = UnityEngine.Random;
using Timer = System.Threading.Timer;

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
      Broker.Subscribe<FighterMessage>(OnFighterReceived);
   }

   private void OnFighterReceived(FighterMessage obj){
      //TODO: add the fighters to correct teams and then start combat.
      
      playerFighter = playerFighters[playerTeamIncrementor];
      enemyFighter = enemyFighters[enemyTeamIncrementor];
      StartCombat();
   }

   private void StartCombat(){
      timer = new Timer(Tick, null, 1000* duration,1000* duration);
   }

   private void Tick(object state){
      StrikeInOrder();
   }
   private void StrikeInOrder(){
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