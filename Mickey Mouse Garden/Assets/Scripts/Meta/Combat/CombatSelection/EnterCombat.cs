using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCombat : MonoBehaviour{
    private Card[] enemyTeamMembers = new Card[3];
    private Card[] playerteamMembers = new Card[3];

    [SerializeField] private CardView[] playerCards;

    private void Awake(){
        Broker.Subscribe<EnterLevelMessage>(OnEnterLevelMessageReceived);
        Broker.Subscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
    }

    void OnDisable(){
        Broker.Unsubscribe<EnterLevelMessage>(OnEnterLevelMessageReceived);
        Broker.Unsubscribe<CardSelectionMessage>(OnSelectedCardMessageReceived);
    }


    private void OnEnterLevelMessageReceived(EnterLevelMessage message){

        for (int i = 0; i < message.CardConfigTeam.Length; i++){

            var cardConfig = message.CardConfigTeam[i];
            
            Card card = new Card("666"){
                ID = new StringGUID().NewGuid(),
                MaxHealth = cardConfig.MaxHealth,
                Attack = cardConfig.Attack,
                Speed = cardConfig.Speed,
                Level = cardConfig.Level,
                Rarity = cardConfig.Rarity,
                Name = cardConfig.Name,
                Alignment = cardConfig.Alignment,
                SpriteIndex = cardConfig.spriteIndex
            };
            
            
            
            enemyTeamMembers[i] = card;
        }
    }
    
    void OnSelectedCardMessageReceived(CardSelectionMessage message){
        playerteamMembers[message.Position] = message.Card;
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
        
        var enemyTeam = ConvertToFighterStack(enemyTeamMembers);
        var enemyTeamSelected = new SelectedFighterTeamMessage {FighterTeam = enemyTeam, IsPlayerTeam = false};
        Broker.InvokeSubscribers(enemyTeamSelected.GetType(), enemyTeamSelected);
        
        SceneManager.UnloadSceneAsync("OpponentSelection");
        //TODO: change into actual proper scene not the temporary testing one
    }

    private Stack<FighterInfo> ConvertToFighterStack(Card[] cards) {
        var team = new Stack<FighterInfo>();
        
        foreach (var card in cards) {
            FighterInfo fighter = new FighterInfo();
            fighter.ID = new StringGUID().NewGuid();
            fighter.MaxHealth = card.MaxHealth;
            fighter.Attack = card.Attack;
            fighter.Speed = card.Speed;
            fighter.Level = card.Level; 
            fighter.Rarity = card.Rarity;
            fighter.Name = card.Name;
            fighter.Alignment = card.Alignment;
            fighter.SpriteIndex = card.SpriteIndex;
            
            team.Push(fighter);
        }
        return team;
    }
}