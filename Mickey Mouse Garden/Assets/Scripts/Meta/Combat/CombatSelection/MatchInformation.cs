using System;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class MatchInformation : MonoBehaviour {
    [SerializeField] private float levelNumber, baseReward  = 100, levelMultiplier = 0.3f, replayMultiplier = 0.4f;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    public bool isUnlocked;
    
    private PlayerLevel playerLevelReference;
    private Money reward;
    public void ConfirmTeam(){
        EnterLevelMessage msg = new(){
            CardConfigTeam = enemyTeamMembers,
            Reward = reward,
            Level = (int)levelNumber
        };
        Broker.InvokeSubscribers(typeof(EnterLevelMessage), msg);
    }

    private void Start(){
        playerLevelReference = FindObjectOfType<Player>().playerLevel;
        
        reward = new() {
            Amount = CalculateReward()
            // Amount = (int) (levelNumber / playerLevelReference.Level * (baseReward * (1 + levelMultiplier * (levelNumber - 1))))
        };
        
        if (playerLevelReference.Level >= levelNumber) {
            isUnlocked = true;
        }
    }

    private int CalculateReward(){
        if (playerLevelReference.Level > levelNumber){
            // Increases payout on higher levels using baseReward + multiplier (currently 30%)
            return (int)(baseReward * (1 + levelMultiplier * (levelNumber - 1)) * replayMultiplier);
        }
        return (int)(baseReward * (1 + levelMultiplier * (levelNumber - 1)));
    }
}