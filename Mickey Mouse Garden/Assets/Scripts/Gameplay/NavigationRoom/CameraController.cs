using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;
	[SerializeField] private GameObject pShopUI, shopUI, shedUI, greenhouseUI;

	[SerializeField] private GameObject viewpoint1, viewpoint2, viewpoint3;
	[SerializeField] private GameObject lookAt1, lookAt2, lookAt3;
	[SerializeField] private float cameraMoveSpeed, cameraRotateSpeed;
	[SerializeField] private Camera thisCamera;
	
	private int viewPointNumber = 1;
	private bool zoomed;
	private Vector3 velocity = Vector3.zero;
	private Transform targetTransform, targetView;
	
	private void Awake() {
		targetView = lookAt1.transform;
		targetTransform = viewpoint1.transform;
		
		pShop.GetComponent<ClickZoom>().selectedEvent.AddListener(LookAtSelection);
		shop.GetComponent<ClickZoom>().selectedEvent.AddListener(LookAtSelection);
		shed.GetComponent<ClickZoom>().selectedEvent.AddListener(LookAtSelection);
		greenhouse.GetComponent<ClickZoom>().selectedEvent.AddListener(LookAtSelection);
		arena.GetComponent<ClickZoom>().selectedEvent.AddListener(LookAtSelection);

		pShopUI.GetComponent<ExitUI>().exitUIEvent.AddListener(LookAway);
		shopUI.GetComponent<ExitUI>().exitUIEvent.AddListener(LookAway);
		shedUI.GetComponent<ExitUI>().exitUIEvent.AddListener(LookAway);
		greenhouseUI.GetComponent<ExitUI>().exitUIEvent.AddListener(LookAway);
	}

	private void Update() {
		var position = transform.position;
		position = Vector3.SmoothDamp(position, targetTransform.position, ref velocity, cameraMoveSpeed);
		transform.position = position;

		var targetRotation = Quaternion.LookRotation(targetView.position - position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraRotateSpeed * Time.deltaTime);
	}
	
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
	
	// Updates targetTransform to position1 and rotation1.
	private void GoToPosition1() {
		targetTransform = viewpoint1.transform;
		targetView = lookAt1.transform;
		viewPointNumber = 1;
	}
	
	// Updates targetTransform to viewpoint2 and rotation2.
	private void GoToPosition2() {
		targetTransform = viewpoint2.transform;
		targetView = lookAt2.transform;
		viewPointNumber = 2;
	}
	// Updates targetTransform to viewpoint3 and rotation3.
	private void GoToPosition3() {
		targetTransform = viewpoint3.transform;
		targetView = lookAt3.transform;
		viewPointNumber = 3;
	}
	
	// Used to transition to store or feature. 
	private void LookAtSelection(Transform objectTransform, string clickName){
		if (!zoomed) {
			targetView = objectTransform;
			thisCamera.fieldOfView = 20;
			zoomed = true;
		}
	}
	private void LookAway(){
		// Resets to previous viewpoint. Stupid but it works.
		thisCamera.fieldOfView = 60;
		GoToLeftViewPoint(); 
		GoToRightViewPoint();
		zoomed = false;
	}
}
