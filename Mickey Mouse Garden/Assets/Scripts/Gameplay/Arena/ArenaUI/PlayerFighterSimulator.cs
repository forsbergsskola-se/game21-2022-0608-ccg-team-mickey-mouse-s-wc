using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFighterSimulator : MonoBehaviour{
	public bool isAlive = true;
	public bool isActive;
	public Sprite sprite;

	public UnityEvent<int> PlayerDedEvent, PlayerActiveEvent;
	
	private void Update(){
		if (!isAlive){
			PlayerDedEvent?.Invoke(GetInstanceID());
			isActive = false;
		}
		if (isActive){
			PlayerActiveEvent?.Invoke(GetInstanceID());
		}
	}
}
