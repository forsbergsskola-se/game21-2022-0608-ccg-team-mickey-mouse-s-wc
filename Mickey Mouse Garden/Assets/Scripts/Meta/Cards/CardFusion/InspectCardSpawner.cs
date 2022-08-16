using System;
using Meta.Cards;
using UnityEngine;
using UnityEngine.UI;

public class InspectCardSpawner : MonoBehaviour{
    [SerializeField] GameObject cardButtonPrefab, spawnPoint, backToSceneButton, quitBackButton;
    [SerializeField] private Image fusionButton;

    private void Awake(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        var instance = Instantiate(cardButtonPrefab, spawnPoint.transform.position,Quaternion.identity,spawnPoint.transform);
        instance.GetComponentInChildren<CardView>().Configure(obj.card);
        
        quitBackButton.SetActive(false);
        fusionButton.color = Color.white;
        backToSceneButton.SetActive(true);
    }
}
