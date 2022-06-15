using UnityEngine;

public class CameraController : MonoBehaviour {
	public float rotationAngle = 30;
	public GameObject clickable1, clickable2, clickable3;
	
	private void Start(){
		clickable1.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomIn);
		clickable2.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomIn);
		clickable3.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomIn);
	}
	
	// Needs to change to fixed positions and angles in scene with smooth damp.
	public void CameraRotateRight(){
		transform.RotateAround(Vector3.zero, Vector3.down, rotationAngle);
	}
	public void CameraRotateLeft(){
		transform.RotateAround(Vector3.zero, Vector3.up, rotationAngle);
	}
	
	// Used to transition to store or feature. May discard if navigation arrows are in world space.
	private void ZoomIn(Vector3 position, int newZoom){
		Camera.main.transform.LookAt(position);
		Camera.main.fieldOfView = newZoom;
	}
	
}
