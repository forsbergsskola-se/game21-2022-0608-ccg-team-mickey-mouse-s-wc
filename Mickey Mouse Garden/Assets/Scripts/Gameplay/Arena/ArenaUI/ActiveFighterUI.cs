using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFighterUI : MonoBehaviour{

	public GameObject activeFighter1, fainted1, greyMask1;
	private void Start() {
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent += ShowDeath;
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent += ShowActive;
	}

	private void ShowDeath(object sender, EventArgs e){
		Debug.Log("Ded");
		fainted1.SetActive(true);
		greyMask1.SetActive(true);
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent -= ShowDeath;
	}
	private void ShowActive(object sender, EventArgs e){
		Debug.Log("Active");
		greyMask1.SetActive(false);
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerActiveEvent -= ShowActive;
	}
}
