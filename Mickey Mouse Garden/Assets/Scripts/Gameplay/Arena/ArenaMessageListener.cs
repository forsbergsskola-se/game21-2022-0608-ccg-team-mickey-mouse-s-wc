using UnityEngine;

public class ArenaMessageListener : MonoBehaviour{
	private ArenaSoundManager arenaSoundManager;
	private int delta;
	private void Awake(){
		arenaSoundManager = GetComponent<ArenaSoundManager>();
		Broker.Subscribe<FighterFaintMessage>(OnFighterFaintMessageReceived);
		Broker.Subscribe<FighterStrikeMessage>(OnFighterStrikeMessageReceived);
		Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateReceived);
		Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<FighterFaintMessage>(OnFighterFaintMessageReceived);
		Broker.Unsubscribe<FighterStrikeMessage>(OnFighterStrikeMessageReceived);
		Broker.Unsubscribe<PostCombatStateMessage>(OnPostCombatStateReceived);
		Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
	}

	private void OnFighterTeamMessageReceived(SelectedFighterTeamMessage obj){
		if (!obj.IsPlayerTeam){
			arenaSoundManager.PlayMusic();
		}
	}

	private void OnFighterStrikeMessageReceived(FighterStrikeMessage obj){
		
		arenaSoundManager.Hit(obj.StrikerAlignment.ToString(), (int)obj.StrikerRarity);
	}
	private void OnFighterFaintMessageReceived(FighterFaintMessage obj){
		arenaSoundManager.Faint();
		switch (obj.wasPlayerFighter){
			case true:
				delta--;
				arenaSoundManager.ModulateMusic(delta);
				break;
			case false:
				delta++;
				arenaSoundManager.ModulateMusic(delta);
				break;
		}
	}
	private void OnPostCombatStateReceived(PostCombatStateMessage obj){
		switch (obj.State){
			case PostCombatState.Victory:
				arenaSoundManager.Victory();
				arenaSoundManager.StopMusic();
				break;
			case PostCombatState.Defeat:
				arenaSoundManager.Defeat();
				arenaSoundManager.StopMusic();
				break;
		}
	}
}
