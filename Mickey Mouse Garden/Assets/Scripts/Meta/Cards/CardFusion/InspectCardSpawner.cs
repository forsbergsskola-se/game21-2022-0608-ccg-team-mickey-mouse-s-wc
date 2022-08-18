using Meta.Cards;
using UnityEngine;
using UnityEngine.UI;

public class InspectCardSpawner : MonoBehaviour{
    [SerializeField] GameObject cardButtonPrefab, spawnPoint, backToSceneButton, quitBackButton, sortButton;
    [SerializeField] private GameObject fusionButton, fusionText;

    private void Awake(){
        Broker.Subscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<InspectCardMessage>(OnInspectCardMessageReceived);
    }

    private void OnInspectCardMessageReceived(InspectCardMessage obj){
        var instance = Instantiate(cardButtonPrefab, spawnPoint.transform.position,Quaternion.identity,spawnPoint.transform);
        instance.GetComponentInChildren<CardView>().Configure(obj.card);
        
        sortButton.GetComponent<Canvas>().enabled = false;
        quitBackButton.SetActive(false);
        fusionButton.GetComponent<Image>().color = Color.white;
        fusionText.SetActive(true);
        fusionButton.GetComponent<Button>().interactable = true;
        backToSceneButton.SetActive(true);
    }
}
