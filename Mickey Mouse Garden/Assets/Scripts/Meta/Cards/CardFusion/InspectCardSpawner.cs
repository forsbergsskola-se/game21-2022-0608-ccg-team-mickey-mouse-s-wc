using System;
using Meta.Cards;
using UnityEngine;

public class InspectCardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardButtonPrefab;

    private void Awake(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        var instance = Instantiate(cardButtonPrefab, new Vector3(124,220,0),Quaternion.identity,gameObject.transform);
        instance.GetComponentInChildren<CardView>().Configure(obj.card);
    }
}
