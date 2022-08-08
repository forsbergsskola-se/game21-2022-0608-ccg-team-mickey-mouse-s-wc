// using System.Collections.Generic;
// using UnityEngine;
//
// public class CombatTester : MonoBehaviour{
//     public Sprite sprite;
//
//     private int id;
//
//     private SelectedFighterTeamMessage MakeAFighterTeam(bool playerteam){
//         //Creating the message and the stack.
//         var team = new SelectedFighterTeamMessage();
//         var fighterStack = new Stack<FighterInfo>();
//        
//         //pushing all the singularfighters into the stack
//         for (int i = 0; i < 3; i++){
//             fighterStack.Push(createFighterInfo());
//         }
//         //set values for the team and the bool if it's the players team or the opponents.
//         team.FighterTeam = fighterStack;
//         team.IsPlayerTeam = playerteam;
//         return team;
//     }
//
//     private void Update(){
//         if (Input.GetKeyDown(KeyCode.F)){
//             //when button F is pressed the playerteam is selected and then the message is sent over to actual combat.
//             SpawnPlayerTeam();
//         }
//         if (Input.GetKeyDown(KeyCode.G)){
//             //when button G is pressed the enemy team is selected and then the message is sent over to actual combat.
//             SpawnEnemyTeam();
//         }
//     }
//     public void SpawnPlayerTeam(){
//
//         var enemyTeam = MakeAFighterTeam(true);
//         Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), enemyTeam);
//     }
//     public void SpawnEnemyTeam(){
//
//         var playerTeam = MakeAFighterTeam(false);
//         Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), playerTeam);
//     }
//
//     private FighterInfo createFighterInfo(){
//         //since fighterInfo is monobehaviour you have to create it inside the message when testing.
//         var fighterMessage = new FighterMessage{
//             
//             //This is where the actual fighter values are assigned, this will be taken from the inventory when selected.
//             fighterInfo = new FighterInfo{ // this is for testing, dont change even though its recommended.
//                 ID = $"{id++}",
//                 MaxHealth = 10,
//                 Attack = 5,
//                 Speed = 10,
//                 Rarity = Rarity.Epic,
//                 Name = "Foo",
//                 Level = 2,
//                 Alignment = Alignment.Scissors,
//                 Sprite = sprite
//             }
//         };
//         return fighterMessage.fighterInfo;
//     }
// }
