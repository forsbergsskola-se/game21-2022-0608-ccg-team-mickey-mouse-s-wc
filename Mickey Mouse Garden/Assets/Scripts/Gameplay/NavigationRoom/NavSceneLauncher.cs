using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour {
	
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;

	private void Awake(){
		pShop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(LaunchScene);
		shop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(LaunchScene);
		shed.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(LaunchScene);
		greenhouse.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(LaunchScene);
		arena.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(LaunchScene);
	}

	private void LaunchScene(Vector3 position, int newZoom, string itemTag){
		Debug.Log(itemTag);

		switch (itemTag) {
			// pShop
			case "PShop":
				SceneManager.LoadScene("ArenaUI", LoadSceneMode.Additive);
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
