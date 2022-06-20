using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavSceneLauncher : MonoBehaviour {
	
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;
	[SerializeField] private GameObject pShopUI, shopUI, shedUI, greenhouseUI;
	
	private void Awake(){
		pShop.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		shop.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		shed.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		greenhouse.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
		arena.GetComponent<ClickZoom>().selectedEvent.AddListener(LaunchScene);
	}

	private void LaunchScene(Transform objectTransform, string itemTag){
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
