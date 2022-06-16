using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFighterSimulator : MonoBehaviour{
	public bool isAlive = true;
	public bool isActive;
	public Sprite sprite;

	public UnityEvent<string> PlayerDedEvent, PlayerActiveEvent;
	
	private void Update(){
		if (!isAlive){
			PlayerDedEvent?.Invoke(gameObject.tag);
			isActive = false;
		}
		if (isActive){
			PlayerActiveEvent?.Invoke(gameObject.tag);
		}
	}
}
