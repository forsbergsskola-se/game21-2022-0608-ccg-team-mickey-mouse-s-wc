using Meta.Cards;
using UnityEngine;

public class BrokerTestCrossScene : MonoBehaviour
{
    private void Awake(){
        Broker.Subscribe<EnterLevelMessage>(OnLevelMessageRecieeved);
    }

    private void OnLevelMessageRecieeved(EnterLevelMessage obj){
        Debug.Log(obj.CardConfigTeam[0]);
        Debug.Log("Made it!");
    }
}
