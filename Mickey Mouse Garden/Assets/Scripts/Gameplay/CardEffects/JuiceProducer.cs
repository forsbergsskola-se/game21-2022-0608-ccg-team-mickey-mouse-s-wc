using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceProducer : MonoBehaviour{

	private ParticleSystem juice;
	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
		juice = GetComponent<ParticleSystem>();
	}
	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		juice.Play();
		Debug.Log("splash");
	}
}
