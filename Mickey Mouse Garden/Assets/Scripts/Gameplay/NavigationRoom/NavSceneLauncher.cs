using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour {
	
	[SerializeField] private GameObject pShopUI, shopUI, shedUI, greenhouseUI;
	
	private void Awake(){
		Broker.Subscribe<UIChangedMessage>(onUIChangedMessageReceived);
	}

	private void onUIChangedMessageReceived(UIChangedMessage obj){
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
				pShopUI.SetActive(true);
				break;
			// shop
			case "Shop":
				shopUI.SetActive(true);
				break;
			// shed
			case "Shed":
				shedUI.SetActive(true);
				break;
			// greenhouse
			case "Garden":
				greenhouseUI.SetActive(true);
				break;
				
			// arena
			case "Arena":
				SceneManager.LoadScene("OpponentSelection");
				break;
		}
	}
}