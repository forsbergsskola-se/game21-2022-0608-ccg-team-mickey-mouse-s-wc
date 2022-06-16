using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour {
	
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;

	private void Awake(){
		pShop.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		shop.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		shed.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		greenhouse.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		arena.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
	}

	private void LaunchScene(Transform objectTransform, string itemTag){
		Debug.Log(itemTag);

		switch (itemTag) {
			// pShop
			case "PShop":
				break;
			// shop
			case "Shop":
				
				break;
			// shed
			case "Shed":
				
				break;
			// greenhouse
			case "Garden":
				
				break;
				
			// arena
			case "Arena":
				SceneManager.LoadScene("OpponentSelection");
				break;
		}
	}
}
