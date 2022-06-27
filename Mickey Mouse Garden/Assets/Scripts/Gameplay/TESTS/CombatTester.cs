using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatTester : MonoBehaviour{
    private Stack<FighterInfo> playerFighters = new Stack<FighterInfo>();
    private Stack<FighterInfo> enemyFighters = new Stack<FighterInfo>();

    public Sprite sprite;

    private int id;

    private SelectedFighterTeamMessage MakeAFighterTeam(bool playerteam){
        SelectedFighterTeamMessage team = new SelectedFighterTeamMessage();
        Stack<FighterInfo> fighterStack = new Stack<FighterInfo>();
       
        for (int i = 0; i < 3; i++){
            fighterStack.Push(createFighterInfo());
        }
        team.FighterTeam = fighterStack;
        team.PlayerTeam = playerteam;
        return team;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.F)){
            SelectedFighterTeamMessage playerteam = MakeAFighterTeam(true);
            Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), playerteam);
        }
        if (Input.GetKeyDown(KeyCode.G)){
            SelectedFighterTeamMessage enemyteam = MakeAFighterTeam(false);
            Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), enemyteam);
        }
    }

    private FighterInfo createFighterInfo(){
        var fighterMessage = new FighterMessage();
        fighterMessage.fighterInfo = new FighterInfo();
        fighterMessage.fighterInfo.ID = id++;
        fighterMessage.fighterInfo.MaxHealth = 10;
        fighterMessage.fighterInfo.Attack = 5;
        fighterMessage.fighterInfo.Speed = 10;
        fighterMessage.fighterInfo.Rarity = Rarity.Epic;
        fighterMessage.fighterInfo.Name = "Foo";
        fighterMessage.fighterInfo.Level = 2;
        fighterMessage.fighterInfo.Alignment = Alignment.Scissors;
        fighterMessage.fighterInfo.Sprite = sprite;
        return fighterMessage.fighterInfo;
    }
}
