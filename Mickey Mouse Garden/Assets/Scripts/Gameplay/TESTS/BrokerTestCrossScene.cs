using Meta.Cards;
using UnityEngine;

public class BrokerTestCrossScene : MonoBehaviour
{
    private void Awake(){
        Broker.Subscribe<LevelMessage>(OnLevelMessageRecieeved);
    }

    private void OnLevelMessageRecieeved(LevelMessage obj){
        Debug.Log(obj.Team[0]);
        Debug.Log("Made it!");
    }
}
