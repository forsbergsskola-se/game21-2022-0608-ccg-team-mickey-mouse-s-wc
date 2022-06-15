using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject pShop, shop, shed, greenHouse, arena;
	public GameObject viewpoint1, viewpoint2, viewpoint3;
	public GameObject lookAt1, lookAt2, lookAt3;
	private int viewPointNumber = 1;
	private bool zoomed;
	private Vector3 velocity = Vector3.zero;
	private Transform targetTransform;
	private Transform targetView;
	public float cameraMoveSpeed;
	public float cameraRotateSpeed;
	private void Awake() {
		targetView = lookAt1.transform;
		targetTransform = viewpoint1.transform;
		pShop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		shop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		shed.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		greenHouse.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		arena.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);

	}

	private void Update(){
		var position = transform.position;
		position = Vector3.SmoothDamp(position, targetTransform.position, ref velocity, cameraMoveSpeed);
		transform.position = position;

		var targetRotation = Quaternion.LookRotation(targetView.position - position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraRotateSpeed * Time.deltaTime);
	}
	// Needs to change to fixed positions and angles in scene with smooth damp.
	
	public void GoToRightViewPoint() {
		switch (viewPointNumber) {
			case 1:
				GoToPosition2();
				break;
			
			case 2:
				GoToPosition3();
				break;
			
			case 3:
				GoToPosition1();
				break;
		}
	}
	
	public void GoToLeftViewPoint() {
		switch (viewPointNumber) {
			case 1:
				GoToPosition3();
				break;
			
			case 2:
				GoToPosition1();
				break;
			
			case 3:
				GoToPosition2();
				break;
		}
	}

	private void GoToPosition1() {
		targetTransform = viewpoint1.transform;
		targetView = lookAt1.transform;
		viewPointNumber = 1;
	}

	private void GoToPosition2() {
		targetTransform = viewpoint2.transform;
		targetView = lookAt2.transform;
		viewPointNumber = 2;
	}

	private void GoToPosition3() {
		targetTransform = viewpoint3.transform;
		targetView = lookAt3.transform;
		viewPointNumber = 3;
	}
	
	// Used to transition to store or feature. 
	private void ZoomChanged(Vector3 position, int newZoom){
		if (!zoomed) {
			targetView.position = position;
			Camera.main.fieldOfView = newZoom;
			zoomed = true;
		} else {
			GoToLeftViewPoint();
			GoToRightViewPoint();
			Camera.main.fieldOfView = newZoom;
			zoomed = false;
		}
	}
}
