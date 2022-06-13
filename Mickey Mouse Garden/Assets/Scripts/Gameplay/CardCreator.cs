using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour{
    private List<FighterMessage> fighters = new List<FighterMessage>();
    private void Awake(){
        Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
    }

    private void OnFighterMessageReceived(FighterMessage obj){
        fighters.Add(obj);
    }
    
    private void OnDestroy(){
        Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
    }
}
