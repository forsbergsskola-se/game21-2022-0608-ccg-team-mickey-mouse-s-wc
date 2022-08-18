using System.Runtime.CompilerServices;
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
		switch (obj.TaskToDo){
			case 1:
				gameObjectTag = obj.ObjectTag;
				break;
			case 2:
				UnLaunch(gameObjectTag);
				break;
		}
	}
	private void UnLaunch(string itemTag){
		switch (itemTag){
			case "PShop":
				SceneManager.UnloadSceneAsync("PShop");
				break;
			case "Shop":
				SceneManager.UnloadSceneAsync("Shop");
				break;
			case "Shed":
				SceneManager.UnloadSceneAsync("Shed");
				break;
			case "Garden":
				SceneManager.UnloadSceneAsync("Garden");
				break;
			case "Arena":
				if (SceneManager.GetSceneByName("OpponentSelection").isLoaded){
					SceneManager.UnloadSceneAsync("OpponentSelection");
				}
				enivronment.SetActive(true);
				GetComponent<MainSceneSoundManager>().UnPauseMusic();
				break;
			default:
				throw new SwitchExpressionException();
		}
	}
}
