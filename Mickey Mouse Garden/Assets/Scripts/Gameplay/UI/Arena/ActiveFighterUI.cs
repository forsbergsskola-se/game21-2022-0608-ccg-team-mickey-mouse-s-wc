using UnityEngine;

public class ActiveFighterUI : MonoBehaviour{

	public GameObject activeFighter1, fainted1, greyMask1, 
						activeFighter2, fainted2, greyMask2, 
						activeFighter3, fainted3, greyMask3;

	private void Awake() {
			activeFighter1.GetComponent<PlayerFighterSimulator>().playerDedEvent.AddListener(ShowDeath);
			activeFighter1.GetComponent<PlayerFighterSimulator>().playerActiveEvent.AddListener(ShowActive);
			
			activeFighter2.GetComponent<PlayerFighterSimulator>().playerDedEvent.AddListener(ShowDeath);
			activeFighter2.GetComponent<PlayerFighterSimulator>().playerActiveEvent.AddListener(ShowActive);
			
			activeFighter3.GetComponent<PlayerFighterSimulator>().playerDedEvent.AddListener(ShowDeath);
			activeFighter3.GetComponent<PlayerFighterSimulator>().playerActiveEvent.AddListener(ShowActive);
	}
	private void ShowDeath(string fighterTag){
		switch (fighterTag){
			case "FF1":
				DisplayDeath(fainted1, greyMask1, activeFighter1);
				break;
			case "FF2":
				DisplayDeath(fainted2, greyMask2, activeFighter2);
				break;
			case "FF3":
				DisplayDeath(fainted3, greyMask3, activeFighter3);
				break;
			case "EF1":
				DisplayDeath(fainted1, greyMask1, activeFighter1);
				break;
			case "EF2":
				DisplayDeath(fainted2, greyMask2, activeFighter2);
				break;
			case "EF3":
				DisplayDeath(fainted3, greyMask3, activeFighter3);
				break;
		}
	}
	private void ShowActive(string fighterTag) {
		switch (fighterTag){
			case "FF1":
				DisplayDeath(greyMask1,activeFighter1);
				break;
			case "FF2":
				DisplayDeath(greyMask2,activeFighter2);
				break;
			case "FF3":
				DisplayDeath(greyMask3,activeFighter3);
				break;
			case "EF1":
				DisplayDeath(greyMask1,activeFighter1);
				break;
			case "EF2":
				DisplayDeath(greyMask2,activeFighter2);
				break;
			case "EF3":
				DisplayDeath(greyMask3,activeFighter3);
				break;
		}
	}
	
	private void DisplayDeath(GameObject fainted, GameObject greyMask,GameObject activeFighter){
		fainted.SetActive(true);
		greyMask.SetActive(true);
		activeFighter.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
	}
	private void DisplayDeath(GameObject greyMask,GameObject activeFighter){
		greyMask1.SetActive(false);
		activeFighter1.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
	}
}
