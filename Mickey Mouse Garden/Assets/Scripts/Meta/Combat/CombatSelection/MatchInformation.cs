using System;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class MatchInformation : MonoBehaviour {
    [SerializeField] private float levelNumber, levelMultiplier = 100;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    public bool isUnlocked;
    
    private PlayerLevel playerLevelReference;
    private Money reward;
    public void ConfirmTeam(){
        EnterLevelMessage msg = new(){
            CardConfigTeam = enemyTeamMembers,
            Reward = reward,
            Level = (int)levelNumber,
            
        };
        Broker.InvokeSubscribers(typeof(EnterLevelMessage), msg);
    }

    private void Start(){
        playerLevelReference = FindObjectOfType<Player>().playerLevel;
        Debug.Log("Level" + playerLevelReference.Level);
        
        reward = new() {
            Amount = (int) (levelNumber / playerLevelReference.Level * levelMultiplier * levelNumber)
        };
        
        Debug.Log(reward);

        if (playerLevelReference.Level >= levelNumber) {
            isUnlocked = true;
        }
    }
}
