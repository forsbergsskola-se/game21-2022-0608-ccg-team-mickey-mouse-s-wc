using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour{

	[SerializeField] private int cameraAngleZoomed, cameraAngleNormal;
	public UnityEvent<Vector3, int> zoomChangedEvent;
	
	private bool zoomed;

	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown(){
		if (!zoomed){
			Debug.Log("Clicked!");
			zoomChangedEvent.Invoke(transform.position, cameraAngleZoomed);
			zoomed = true;
		} else {
			zoomChangedEvent.Invoke(transform.position, cameraAngleNormal);
			zoomed = false;
		}
	}
}
