using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
		Debug.Log(fighterTag);
		switch (fighterTag){
			case "FF1":
				fainted1.SetActive(true);
				greyMask1.SetActive(true);
				activeFighter1.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
			case "FF2":
				fainted2.SetActive(true);
				greyMask2.SetActive(true);
				activeFighter2.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
			case "FF3":
				fainted3.SetActive(true);
				greyMask3.SetActive(true);
				activeFighter3.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
			case "EF1":
				fainted1.SetActive(true);
				greyMask1.SetActive(true);
				activeFighter1.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
			case "EF2":
				fainted2.SetActive(true);
				greyMask2.SetActive(true);
				activeFighter2.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
			case "EF3":
				fainted3.SetActive(true);
				greyMask3.SetActive(true);
				activeFighter3.GetComponent<PlayerFighterSimulator>().playerDedEvent.RemoveListener(ShowDeath);
				break;
		}
	}
	private void ShowActive(string fighterTag) {
		Debug.Log("Active");
		switch (fighterTag){
			case "FF1":
				greyMask1.SetActive(false);
				activeFighter1.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
			case "FF2":
				greyMask2.SetActive(false);
				activeFighter2.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
			case "FF3":
				greyMask3.SetActive(false);
				activeFighter3.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
			case "EF1":
				greyMask1.SetActive(false);
				activeFighter1.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
			case "EF2":
				greyMask2.SetActive(false);
				activeFighter2.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
			case "EF3":
				greyMask3.SetActive(false);
				activeFighter3.GetComponent<PlayerFighterSimulator>().playerActiveEvent.RemoveListener(ShowActive);
				break;
		}
	}
}
