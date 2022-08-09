using System;
using Meta.Cards;
using UnityEngine;

public class MatchInformation : MonoBehaviour {
    [SerializeField] private float levelNumber, levelMultiplier = 100;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    public bool isUnlocked;
    
    private PlayerLevel playerLevelReference;
    private Money reward;
    public void ConfirmTeam(){
        LevelMessage msg = new(){
            Team = enemyTeamMembers,
            Reward = reward,
            Level = (int)levelNumber,
            
        };
        Broker.InvokeSubscribers(typeof(LevelMessage), msg);
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