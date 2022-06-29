using Meta.Cards;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private string levelName;
    [SerializeField] private CardConfig[] enemyTeamMembers; //TODO: force amount of elements to be 3, pesky designers.
    
    public void ConfirmTeam(){
        LevelMessage msg = new LevelMessage{Team = enemyTeamMembers};
        Broker.InvokeSubscribers(typeof(LevelMessage), msg);
    }
}
