using System;
using Meta.Cards;
using UnityEngine;

public class InspectCardSpawner : MonoBehaviour{
    [SerializeField] GameObject cardButtonPrefab, spawnPoint;

    private void Awake(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        var instance = Instantiate(cardButtonPrefab, spawnPoint.transform.position,Quaternion.identity,spawnPoint.transform);
        instance.GetComponentInChildren<CardView>().Configure(obj.card);
    }
}
