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
		
		arenaSoundManager.Hit(obj.StrikerAlignment.ToString(), obj.StrikerRarity.ToString());
	}
	private void OnFighterFaintMessageReceived(FighterFaintMessage obj){
		arenaSoundManager.Faint();
		
		if (obj.wasPlayerFighter){
			delta--;
			arenaSoundManager.ModulateMusic(delta);
		}
		if (!obj.wasPlayerFighter){
			delta++;
			arenaSoundManager.ModulateMusic(delta);
		}
	}
	private void OnPostCombatStateReceived(PostCombatStateMessage obj){
		if (obj.State == PostCombatState.Victory){
			arenaSoundManager.Victory();
			arenaSoundManager.StopMusic();
		}  
		if (obj.State == PostCombatState.Defeat) {
			arenaSoundManager.Defeat();
			arenaSoundManager.StopMusic();
		}
	}
}
