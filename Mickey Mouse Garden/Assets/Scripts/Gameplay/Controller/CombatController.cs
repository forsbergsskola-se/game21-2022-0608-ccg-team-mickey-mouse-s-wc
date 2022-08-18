using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Timer = System.Threading.Timer;

public class CombatController : MonoBehaviour{
   private Stack<FighterInfo> playerFighters = new();
   private Stack<FighterInfo> enemyFighters = new();

   [SerializeField] private int duration;

   private FighterInfo playerFighter;
   private FighterInfo enemyFighter;
   
   private bool playerGoesFirst;
   
   private Executor executor;
   private Timer timer;

   private void Awake(){
      executor = FindObjectOfType<Executor>();
      Broker.Subscribe<FighterFaintMessage>(OnDeathMessageReceived);
      Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterTeamReceived);
   }

   private void OnDisable(){
      Broker.Unsubscribe<FighterFaintMessage>(OnDeathMessageReceived);
      Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterTeamReceived);
   }

   private void OnFighterTeamReceived(SelectedFighterTeamMessage obj){
      if (obj.IsPlayerTeam){
         playerFighters = obj.FighterTeam;
      }
      else{
         enemyFighters = obj.FighterTeam;
      }
      
      if (enemyFighters.Count > 1){
         StartCoroutine(StartCombat());
      }
   }

   private IEnumerator StartCombat(){
      yield return new WaitForSeconds(0.3f);
      NextFighter();
      AssertStrikeOrder();
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

   private void OnDeathMessageReceived(FighterFaintMessage obj){
      if (obj.wasPlayerFighter){
         if (playerFighters.TryPop(out var temp)){
            playerFighter = temp;
         }
      }
      else{
         if (enemyFighters.TryPop(out var temp)){
            enemyFighter = temp;
         }
      }
      if (playerFighter.MaxHealth <= 0 || enemyFighter.MaxHealth <= 0){
         timer.Dispose();
         executor.Enqueue(new EndOfCombatCommand(enemyFighter.MaxHealth <= 0));  
      }
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
      playerFighters.TryPop(out playerFighter);
      enemyFighters.TryPop(out enemyFighter);
   }
}