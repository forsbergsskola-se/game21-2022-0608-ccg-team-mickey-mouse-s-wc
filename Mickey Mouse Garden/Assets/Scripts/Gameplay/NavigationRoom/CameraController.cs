using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject clickable1, clickable2, clickable3;
	public GameObject viewpoint1, viewpoint2, viewpoint3;
	public GameObject lookAt1, lookAt2, lookAt3;
	private int viewPointNumber = 1;
	
	private void Awake(){
		clickable1.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		clickable2.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
		clickable3.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(ZoomChanged);
	}
	
	// Needs to change to fixed positions and angles in scene with smooth damp.
	
	public void GoToRightViewPoint() {
		switch (viewPointNumber) {
			case 1:
				transform.position = viewpoint2.transform.position;
				transform.LookAt(lookAt2.transform.position);
				viewPointNumber = 2;
				break;
			
			case 2:
				transform.position = viewpoint3.transform.position;
				transform.LookAt(lookAt3.transform.position);
				viewPointNumber = 3;
				break;
			
			case 3:
				transform.position = viewpoint1.transform.position;
				transform.LookAt(lookAt1.transform.position);
				viewPointNumber = 1;
				break;
		}
	}
	
	public void GoToRLeftViewPoint() {
		switch (viewPointNumber) {
			case 1:
				transform.position = viewpoint3.transform.position;
				transform.LookAt(lookAt3.transform.position);
				viewPointNumber = 3;
				break;
			
			case 2:
				transform.position = viewpoint1.transform.position;
				transform.LookAt(lookAt1.transform.position);
				viewPointNumber = 1;
				break;
			
			case 3:
				transform.position = viewpoint2.transform.position;
				transform.LookAt(lookAt2.transform.position);
				viewPointNumber = 2;
				break;
		}
	}
	
	// Used to transition to store or feature. 
	private void ZoomChanged(Vector3 position, int newZoom){
		Camera.main.transform.LookAt(position);
		Camera.main.fieldOfView = newZoom;
	}
	
}
