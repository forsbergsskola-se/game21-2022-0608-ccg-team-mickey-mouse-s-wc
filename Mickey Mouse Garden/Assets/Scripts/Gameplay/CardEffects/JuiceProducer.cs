using System;
using UnityEngine;

public class JuiceProducer : MonoBehaviour{

	private ParticleSystem juice;
	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
		juice = GetComponent<ParticleSystem>();
	}
	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		juice.Play();
	}

	private void OnDisable(){
		Broker.Unsubscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}
}
