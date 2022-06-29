using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;

public class BrokerTestCrossScene : MonoBehaviour
{
    private void Awake(){
        Broker.Subscribe<LevelMessage>(OnLevelMessageRecieeved);
    }

    private void OnLevelMessageRecieeved(LevelMessage obj){
        Debug.Log("Made it!");
    }
}
