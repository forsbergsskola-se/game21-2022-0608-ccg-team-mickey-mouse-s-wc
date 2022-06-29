using Meta.Cards;
using UnityEngine;

public class Level : MonoBehaviour {
    public string levelName;
    public CardConfig[] enemyTeamMembers;
    
    public void ConfirmTeam(){
        LevelMessage msg = new LevelMessage{Team = enemyTeamMembers};
        Broker.InvokeSubscribers(typeof(LevelMessage), msg);
    }
}
