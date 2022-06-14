using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFighterSimulator : MonoBehaviour{
	public bool isAlive = true;

	public event EventHandler PlayerDedEvent;

	private void Update(){
		if (!isAlive){
			PlayerDedEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
