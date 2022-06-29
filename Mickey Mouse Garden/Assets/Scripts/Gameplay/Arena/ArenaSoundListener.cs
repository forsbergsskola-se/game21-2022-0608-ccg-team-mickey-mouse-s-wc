using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSoundListener : MonoBehaviour{
	[SerializeField] private FMODUnity.EventReference arenaBackground;
	private void Awake(){
		Broker.Subscribe<FighterFaintMessage>(OnFighterFaintMessageReceived);
		Broker.Subscribe<FighterStrikeMessage>(OnFighterStrikeMessageReceived);
		Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateReceived);
		var arenaBackgroundInstance = FMODUnity.RuntimeManager.CreateInstance(arenaBackground);
		arenaBackgroundInstance.start();
	}

	private void OnFighterStrikeMessageReceived(FighterStrikeMessage obj){
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Hits");
	}
	private void OnFighterFaintMessageReceived(FighterFaintMessage obj){
		
	}
	private void OnPostCombatStateReceived(PostCombatStateMessage obj){
		if (obj.State == PostCombatState.Victory){
			FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Victory");
		}  
		if (obj.State == PostCombatState.Defeat) {
			FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Defeat");
		}
	}
}
