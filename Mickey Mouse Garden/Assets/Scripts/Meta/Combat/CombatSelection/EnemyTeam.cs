using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class EnemyTeam : MonoBehaviour {
    public string Level;
    public CardConfig[] EnemyTeamMembers;
    
    public void EnterCombat() {
        Stack<FighterInfo> team = ConvertToFighterStack();
        var enemyTeamSelected = new SelectedFighterTeamMessage {FighterTeam = team, IsPlayerTeam = false};
        Broker.InvokeSubscribers(enemyTeamSelected.GetType(), enemyTeamSelected);
    }
    
    private Stack<FighterInfo> ConvertToFighterStack() {
        Stack<FighterInfo> team = new Stack<FighterInfo>();
        
        foreach (var enemy in EnemyTeamMembers) {
            FighterInfo fighter = new FighterInfo();
            fighter.ID = enemy.id;
            fighter.MaxHealth = enemy.maxHealth;
            fighter.Attack = enemy.attack;
            fighter.Speed = enemy.speed;
            fighter.Level = 1; //TODO: Implement in card config
            fighter.Rarity = enemy.rarity;
            fighter.Name = enemy.name;
            fighter.Alignment = enemy.alignment;
            fighter.Sprite = enemy.image;
            
            team.Push(fighter);
        }

        return team;
    }
}
