using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitUI : MonoBehaviour{

	[SerializeField] private GameObject enivronment;

	private string gameObjectTag;
	private void Awake(){
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnUIChangedMessageReceived(UIChangedMessage obj){
		if (obj.TaskToDo == 1){
			gameObjectTag = obj.ObjectTag;
		}
		if (obj.TaskToDo == 2){
			Debug.Log(gameObjectTag);
			UnLaunch(gameObjectTag);
		}
	}
	private void UnLaunch(string itemTag){
		switch (itemTag){
			// pShop
			case "PShop":
				SceneManager.UnloadSceneAsync("PShop");
				break;
			// shop
			case "Shop":
				SceneManager.UnloadSceneAsync("Shop");
				break;
			// shed
			case "Shed":
				SceneManager.UnloadSceneAsync("Shed");
				break;
			// garden
			case "Garden":
				SceneManager.UnloadSceneAsync("Garden");
				break;

			// arena
			case "Arena":
				if (SceneManager.GetSceneByName("OpponentSelection").isLoaded){
					SceneManager.UnloadSceneAsync("OpponentSelection");
				}
				enivronment.SetActive(true);
				GetComponent<MainSceneSoundManager>().UnPauseMusic();
				break;
		}
	}
}
