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

		// var alignment = obj.StrikerAlignment switch{
		// 	Alignment.Rock => 1,
		// 	Alignment.Paper => 2,
		// 	Alignment.Scissors => 3
		// };
		// var rarity = obj.StrikerRarity switch{
		// 	Rarity.Common => 1,
		// 	Rarity.Rare => 2,
		// 	Rarity.Epic => 3,
		// 	Rarity.Legendary => 4
		// };

		arenaSoundManager.Hit(obj.DamageDealt, obj.StrikerAlignment.ToString(), obj.StrikerRarity.ToString());
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
