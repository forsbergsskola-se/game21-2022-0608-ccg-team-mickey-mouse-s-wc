using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFighterSimulator : MonoBehaviour{
	public bool isAlive = true;
	public bool isActive;
	public Sprite sprite;

	public event EventHandler PlayerDedEvent;
	public event EventHandler PlayerActiveEvent;
	
	private void Update(){
		if (!isAlive){
			PlayerDedEvent?.Invoke(this, EventArgs.Empty);
		}
		if (isActive){
			PlayerActiveEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
