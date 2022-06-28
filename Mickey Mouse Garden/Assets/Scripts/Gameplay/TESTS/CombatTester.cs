using System.Collections.Generic;
using UnityEngine;

public class CombatTester : MonoBehaviour{
    public Sprite sprite;

    private int id;

    private SelectedFighterTeamMessage MakeAFighterTeam(bool playerteam){
        var team = new SelectedFighterTeamMessage();
        var fighterStack = new Stack<FighterInfo>();
       
        for (int i = 0; i < 3; i++){
            fighterStack.Push(createFighterInfo());
        }
        team.FighterTeam = fighterStack;
        team.PlayerTeam = playerteam;
        return team;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.F)){
            var playerTeam = MakeAFighterTeam(true);
            Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), playerTeam);
        }
        if (Input.GetKeyDown(KeyCode.G)){
            var enemyTeam = MakeAFighterTeam(false);
            Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), enemyTeam);
        }
    }

    private FighterInfo createFighterInfo(){
        var fighterMessage = new FighterMessage{
            fighterInfo = new FighterInfo{ // this is for testing, dont change even though its recommended.
                ID = id++,
                MaxHealth = 10,
                Attack = 5,
                Speed = 10,
                Rarity = Rarity.Epic,
                Name = "Foo",
                Level = 2,
                Alignment = Alignment.Scissors,
                Sprite = sprite
            }
        };
        return fighterMessage.fighterInfo;
    }
}
