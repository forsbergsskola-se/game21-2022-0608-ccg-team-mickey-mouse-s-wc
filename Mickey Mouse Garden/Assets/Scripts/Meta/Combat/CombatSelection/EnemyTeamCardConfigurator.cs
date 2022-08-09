using System;
using Meta.Cards;
using UnityEngine;

public class EnemyTeamCardConfigurator : MonoBehaviour{
    private CardView[] enemyteam;

    private void Awake(){
        enemyteam = GetComponentsInChildren<CardView>();
        Broker.Subscribe<EnterLevelMessage>(OnLevelMessageRecieevved);
    }

    private void OnLevelMessageRecieevved(EnterLevelMessage obj){
        for (var i = 0; i < enemyteam.Length; i++){
            enemyteam[i].Configure(obj.CardConfigTeam[i]);
        }
    }
}
