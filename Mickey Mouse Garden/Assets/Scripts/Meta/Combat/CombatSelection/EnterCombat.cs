using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCombat : MonoBehaviour{
    private CardConfig[] enemyTeamMembers = new CardConfig[3];
    private Card[] playerteamMembers = new Card[3];

    [SerializeField] private CardView[] playerCards;

    private void Awake(){
        Broker.Subscribe<LevelMessage>(OnLevelMessageRecieved);
    }

    private void OnLevelMessageRecieved(LevelMessage message){
        enemyTeamMembers = message.CardConfigTeam;
    }

    public void StartFight(){
        SceneManager.LoadScene("Arena", LoadSceneMode.Additive);
        StartCoroutine(PrepareForArena());
    }

    private IEnumerator PrepareForArena(){
        yield return new WaitForSeconds(0.1f);
        for (var i = 0; i < playerCards.Length; i++){
            var card = playerCards[i].GetComponentInChildren<ASelectedCard>().FindCardData();
            playerteamMembers[i] = card;
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

    private Stack<FighterInfo> ConvertToFighterStack(Card[] cards) {
        var team = new Stack<FighterInfo>();
        
        foreach (var card in cards) {
            FighterInfo fighter = new FighterInfo();
            fighter.ID = card.ID;
            fighter.MaxHealth = card.MaxHealth;
            fighter.Attack = card.Attack;
            fighter.Speed = card.Speed;
            fighter.Level = card.Level; 
            fighter.Rarity = card.Rarity;
            fighter.Name = card.Name;
            fighter.Alignment = card.Alignment;
            fighter.Sprite = card.FighterImage;
            
            team.Push(fighter);
        }
        return team;
    }
    
    private Stack<FighterInfo> ConvertToFighterStack(CardConfig[] cards) {
        var team = new Stack<FighterInfo>();
        
        foreach (var card in cards) {
            FighterInfo fighter = new FighterInfo();
            fighter.ID = new StringGUID(card.id);
            fighter.MaxHealth = card.maxHealth;
            fighter.Attack = card.attack;
            fighter.Speed = card.speed;
            fighter.Level = card.level; 
            fighter.Rarity = card.rarity;
            fighter.Name = card.name;
            fighter.Alignment = card.alignment;
            fighter.Sprite = card.image;
            
            team.Push(fighter);
        }
        return team;
    }
}
