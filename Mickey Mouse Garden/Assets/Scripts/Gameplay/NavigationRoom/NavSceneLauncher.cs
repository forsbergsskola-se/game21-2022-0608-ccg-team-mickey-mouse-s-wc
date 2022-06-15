using System;
using System.Collections;
using System.Collections.Generic;
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

	private void LaunchScene(Vector3 position, int newZoom, int instanceID){
		Debug.Log(instanceID);

		switch (instanceID) {
			// pShop
			case 43876:
				SceneManager.LoadScene("ArenaUI", LoadSceneMode.Additive);
				break;
			// shop
			case 43912:
				
				break;
			// shed
			case 43890:
				
				break;
			// greenhouse
			case 43940:
				
				break;
				
			// arena
			case 43992:
				SceneManager.LoadScene("Arena");
				break;
		}
	}
}
