using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour{

	[SerializeField] private GameObject enivronment;
	private void Awake(){
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
		Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
	}
	private void OnPostCombatStateMessageReceived(PostCombatStateMessage obj){
		StartCoroutine(DelayEnvironment());
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

	private IEnumerator DelayEnvironment(){
		yield return new WaitForSeconds(1);
		enivronment.SetActive(true);
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
			// garden
			case "Garden":
				SceneManager.LoadScene("Garden", LoadSceneMode.Additive);
				// greenhouseUI.SetActive(true);
				break;
				
			// arena
			case "Arena":
				enivronment.SetActive(false);
				SceneManager.LoadScene("OpponentSelection", LoadSceneMode.Additive);
				break;
		}
	}
}