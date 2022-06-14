using UnityEngine;

public class CameraController : MonoBehaviour{
	public float newZoom;
	public float rotationAngle = 30;
	public GameObject clickable1, clickable2, clickable3;
	
	private float originalZoom;

	private void Start(){
			
		clickable1.GetComponent<ClickZoom>().zoomedInEvent.AddListener(ZoomIn);
		clickable1.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(ZoomOut);
		clickable2.GetComponent<ClickZoom>().zoomedInEvent.AddListener(ZoomIn);
		clickable2.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(ZoomOut);
		clickable3.GetComponent<ClickZoom>().zoomedInEvent.AddListener(ZoomIn);
		clickable3.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(ZoomOut);
		
		originalZoom = Camera.main.fieldOfView;
	}
	public void CameraRotateRight(){
		transform.RotateAround(Vector3.zero, Vector3.down, rotationAngle);
	}
	public void CameraRotateLeft(){
		transform.RotateAround(Vector3.zero, Vector3.up, rotationAngle);
	}
	
	private void ZoomIn(Vector3 position){
		Camera.main.transform.LookAt(position);
		Camera.main.fieldOfView = newZoom;
	}
	
	private void ZoomOut(){
		Camera.main.fieldOfView = originalZoom;
	}
}
