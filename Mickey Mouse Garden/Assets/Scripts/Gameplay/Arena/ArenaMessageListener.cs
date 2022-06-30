using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMessageListener : MonoBehaviour{
	private ArenaSoundManager arenaSoundManager;
	private void Awake(){
		arenaSoundManager = GetComponent<ArenaSoundManager>();
		Broker.Subscribe<FighterFaintMessage>(OnFighterFaintMessageReceived);
		Broker.Subscribe<FighterStrikeMessage>(OnFighterStrikeMessageReceived);
		Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateReceived);
	}

	private void OnFighterStrikeMessageReceived(FighterStrikeMessage obj){
		arenaSoundManager.Hit();
	}
	private void OnFighterFaintMessageReceived(FighterFaintMessage obj){
		arenaSoundManager.Faint();
	}
	private void OnPostCombatStateReceived(PostCombatStateMessage obj){
		if (obj.State == PostCombatState.Victory){
			arenaSoundManager.Victory();
			arenaSoundManager.Silence();
		}  
		if (obj.State == PostCombatState.Defeat) {
			arenaSoundManager.Defeat();
			arenaSoundManager.Silence();
		}
	}
}
