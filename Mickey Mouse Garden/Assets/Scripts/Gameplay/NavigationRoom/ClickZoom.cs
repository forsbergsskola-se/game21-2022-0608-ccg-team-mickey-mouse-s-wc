using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour {

	public UnityEvent<Vector3> zoomedInEvent;
	public UnityEvent zoomedOutEvent;
	
	private bool zoomed;
	private Vector3 touchPosition;
	

	private void OnMouseDown(){
		if (!zoomed){
			Debug.Log("Store!");
			zoomedInEvent.Invoke(transform.position);
			zoomed = true;
		} else {
			zoomedOutEvent.Invoke();
			zoomed = false;
		}
	}
}
