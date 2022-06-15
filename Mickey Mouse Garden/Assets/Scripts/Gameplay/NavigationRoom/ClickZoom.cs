using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour {

	public UnityEvent<Vector3, int> zoomChangedEvent;
	
	private bool zoomed;

	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown(){
		if (!zoomed){
			Debug.Log("Clicked!");
			zoomChangedEvent.Invoke(transform.position, 20);
			zoomed = true;
		} else {
			zoomChangedEvent.Invoke(transform.position, 60);
			zoomed = false;
		}
	}
}
