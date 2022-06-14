using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZoom : MonoBehaviour {

	public float newZoom;
	private bool zoomed;
	private float originalZoom;
	private Vector3 touchPosition;

	private TouchPhase touchPhase = TouchPhase.Ended;
	private void Start(){
		originalZoom = Camera.main.fieldOfView;
	}
	private void OnMouseDown(){
		if (!zoomed){
			LookAtTarget();
			ZoomIn();
			Debug.Log("Store!");
			zoomed = true;
		} else {
			ZoomOut();
			zoomed = false;
		}
	}

	private void LookAtTarget(){
		Camera.main.transform.LookAt(transform.position);
	}

	private void ZoomIn(){
		Camera.main.fieldOfView = newZoom;
	}
	
	private void ZoomOut(){
		Camera.main.fieldOfView = originalZoom;
	}
}
