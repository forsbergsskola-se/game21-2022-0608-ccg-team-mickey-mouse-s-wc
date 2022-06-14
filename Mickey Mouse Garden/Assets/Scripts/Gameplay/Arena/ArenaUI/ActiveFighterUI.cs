using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFighterUI : MonoBehaviour{

	public GameObject activeFighter1, fainted1, greyMask1;
	private void Start() {
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent += ShowDeath;
	}

	private void ShowDeath(object sender, EventArgs e){
		Debug.Log("Ded");
		fainted1.SetActive(true);
		greyMask1.SetActive(true);
		activeFighter1.GetComponent<PlayerFighterSimulator>().PlayerDedEvent -= ShowDeath;
	}
}
