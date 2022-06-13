using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    public GameObject card;
    private List<FighterInfo> fighters = new List<FighterInfo>();
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighters.Add(obj.fighterInfo);
    }

    private void AllFightersGathered(){
        foreach (var fighter in fighters){
            Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
        }
        Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
    }
    
    private void OnDestroy(){
        Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
    }
}
