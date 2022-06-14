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
			activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.AddListener(ShowDeath);
			activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.AddListener(ShowActive);
			
			activeFighter2.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.AddListener(ShowDeath);
			activeFighter2.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.AddListener(ShowActive);
			
			activeFighter3.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.AddListener(ShowDeath);
			activeFighter3.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.AddListener(ShowActive);
	}
	private void ShowDeath(int id){
		Debug.Log(id);
		switch (id){
			case 31532:
				fainted1.SetActive(true);
				greyMask1.SetActive(true);
				activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.RemoveListener(ShowDeath);
				break;
			case -132182:
				fainted2.SetActive(true);
				greyMask2.SetActive(true);
				activeFighter2.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.RemoveListener(ShowDeath);
				break;
			case -137220:
				fainted3.SetActive(true);
				greyMask3.SetActive(true);
				activeFighter3.GetComponent<PlayerFighterSimulator>().PlayerDedEvent.RemoveListener(ShowDeath);
				break;
		}
	}
	private void ShowActive(int id) {
		Debug.Log("Active");
		switch (id){
			case 31532:
				greyMask1.SetActive(false);
				activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.RemoveListener(ShowActive);
				break;
			case -132182:
				greyMask2.SetActive(false);
				activeFighter2.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.RemoveListener(ShowActive);
				break;
			case -137220:
				greyMask3.SetActive(false);
				activeFighter3.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent.RemoveListener(ShowActive);
				break;
		}
	}
}
