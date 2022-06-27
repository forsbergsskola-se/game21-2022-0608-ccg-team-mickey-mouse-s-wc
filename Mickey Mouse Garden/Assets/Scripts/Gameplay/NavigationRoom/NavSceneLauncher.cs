using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour {
	
	
	private void Awake(){
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnUIChangedMessageReceived(UIChangedMessage obj){
		if (obj.TaskToDo == 1){
			LaunchScene(obj.ObjectTag);
		}
	}

	private void LaunchScene(string itemTag){
		StartCoroutine(WaitForZoom(itemTag));
	}
	private IEnumerator WaitForZoom(string itemTag){
		yield return new WaitForSeconds(0.25f);
		Launch(itemTag);
	}

	private void Launch(string itemTag){
		switch (itemTag) {
			// pShop
			case "PShop":
				SceneManager.LoadScene("PShop", LoadSceneMode.Additive);
				break;
			// shop
			case "Shop":
				SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
				break;
			// shed
			case "Shed":
				SceneManager.LoadScene("Shed", LoadSceneMode.Additive);
				break;
			// greenhouse
			case "Garden":
				SceneManager.LoadScene("InventoryTestScene", LoadSceneMode.Additive);
				// greenhouseUI.SetActive(true);
				break;
				
			// arena
			case "Arena":
				SceneManager.LoadScene("OpponentSelection", LoadSceneMode.Additive);
				break;
		}
	}
}