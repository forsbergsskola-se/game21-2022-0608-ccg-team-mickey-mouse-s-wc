using Meta.Cards;
using UnityEngine;

public class MatchInformation : MonoBehaviour {
    public bool isUnlocked;
    [SerializeField] private float levelNumber, baseReward  = 100, levelMultiplier = 0.3f, replayMultiplier = 0.4f;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    
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
        };
        
        if (playerLevelReference.Level >= levelNumber) {
            isUnlocked = true;
        }
    }

    private int CalculateReward(){
        if (playerLevelReference.Level > levelNumber){
            // Increases payout on higher levels using baseReward + multiplier
            return (int)(baseReward * (1 + levelMultiplier * (levelNumber - 1)) * replayMultiplier);
        }
        
        return (int)(baseReward * (1 + levelMultiplier * (levelNumber - 1)));
    }
}