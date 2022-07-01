using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCombat : MonoBehaviour{
    private CardConfig[] enemyTeamMembers = new CardConfig[3];
    private CardConfig[] playerteamMembers = new CardConfig[3];

    [SerializeField] private CardView[] playerCards;

    private void Awake(){
        Broker.Subscribe<LevelMessage>(OnLevelMessageRecieved);
    }

    private void OnLevelMessageRecieved(LevelMessage obj){
        enemyTeamMembers = obj.Team;
    }

    public void StartFight(){
        SceneManager.LoadScene("Arena", LoadSceneMode.Additive);
        StartCoroutine(PrepareForArena());
    }

    private IEnumerator PrepareForArena(){
        yield return new WaitForSeconds(0.1f);
        for (var i = 0; i < playerCards.Length; i++){
            var config = playerCards[i].GetComponentInChildren<ASelectedCard>().FindCardData();
            playerteamMembers[i] = config;
        }
        var playerTeam = ConvertToFighterStack(playerteamMembers);
        var selectedPlayerTeam = new SelectedFighterTeamMessage{FighterTeam = playerTeam, IsPlayerTeam = true};
        Broker.InvokeSubscribers(typeof(SelectedFighterTeamMessage), selectedPlayerTeam);
        
        yield return new WaitForSeconds(0.5f);
        
        var enemyTeam = ConvertToFighterStack(enemyTeamMembers);
        var enemyTeamSelected = new SelectedFighterTeamMessage {FighterTeam = enemyTeam, IsPlayerTeam = false};
        Broker.InvokeSubscribers(enemyTeamSelected.GetType(), enemyTeamSelected);
        
        SceneManager.UnloadSceneAsync("2TeamSel");
        //TODO: change into actual proper scene not the temporary testing one
    }

    private Stack<FighterInfo> ConvertToFighterStack(CardConfig[] configArr) {
        var team = new Stack<FighterInfo>();
        
        foreach (var enemy in configArr) {
            FighterInfo fighter = new FighterInfo();
            fighter.ID = enemy.id;
            fighter.MaxHealth = enemy.maxHealth;
            fighter.Attack = enemy.attack;
            fighter.Speed = enemy.speed;
            fighter.Level = enemy.level; 
            fighter.Rarity = enemy.rarity;
            fighter.Name = enemy.name;
            fighter.Alignment = enemy.alignment;
            fighter.Sprite = enemy.image;
            
            team.Push(fighter);
        }
        return team;
    }
}
