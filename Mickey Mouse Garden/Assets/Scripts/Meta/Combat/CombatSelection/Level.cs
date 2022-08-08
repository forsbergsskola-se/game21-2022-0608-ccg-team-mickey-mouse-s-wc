using System;
using Meta.Cards;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private float levelNumber, levelMultiplier = 100;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    private PlayerLevel playerLevel;
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
        playerLevel = FindObjectOfType<Player>().GetComponent<PlayerLevel>();
        reward.Amount = (int)(levelNumber / playerLevel.Level * levelMultiplier * levelNumber);
        Debug.Log(reward);
    }
}
