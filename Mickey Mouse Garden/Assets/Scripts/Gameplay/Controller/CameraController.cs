using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	[SerializeField] private GameObject viewpoint1, viewpoint2, viewpoint3;
	[SerializeField] private GameObject lookAt1, lookAt2, lookAt3;
	[SerializeField] private float cameraMoveSpeed, cameraRotateSpeed, cameraZoomSpeed;
	[SerializeField] private Camera thisCamera;
	
	private int viewPointNumber = 1;
	private bool zoomed;
	private Vector3 velocity = Vector3.zero;
	private Transform targetTransform, targetView;
	private float newFOV = 60;
	private MainSceneSoundManager mainSceneSoundManager;
	
	private void Awake() {
		targetView = lookAt1.transform;
		targetTransform = viewpoint1.transform;
		mainSceneSoundManager = GetComponent<MainSceneSoundManager>();
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnUIChangedMessageReceived(UIChangedMessage obj){
		switch (obj.TaskToDo){
			case 1:
				LookAtSelection(obj.ObjectTransform);
				break;
			case 2:
				LookAway();
				break;
		}
	}

	private void Update() {
		var position = MoveCamera();
		
		CalculatingSoundParameter(position);

		RotateCamera(position);

		AssignFOV();
	}

	void AssignFOV(){
		var currentFOV = thisCamera.fieldOfView;
		thisCamera.fieldOfView = Mathf.Lerp(currentFOV, newFOV, cameraZoomSpeed * Time.deltaTime);
	}

	void RotateCamera(Vector3 position){
		var targetRotation = Quaternion.LookRotation(targetView.position - position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraRotateSpeed * Time.deltaTime);
	}

	Vector3 MoveCamera(){
		var position = transform.position;
		position = Vector3.SmoothDamp(position, targetTransform.position, ref velocity, cameraMoveSpeed);
		transform.position = position;
		return position;
	}

	void CalculatingSoundParameter(Vector3 position){
		var distanceTo3 = Vector3.Distance(position, viewpoint3.transform.position);
		SendXPosition(distanceTo3);
	}

	private void SendXPosition(float xPosition){
		CamPositionMessage camPositionMessage = new(){Distance = xPosition};
		Broker.InvokeSubscribers(typeof(CamPositionMessage), camPositionMessage);
	}
	
	public void GoToRightViewPoint(){
		mainSceneSoundManager.MainClick();
		mainSceneSoundManager.Swoosh();
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
		mainSceneSoundManager.MainClick();
		mainSceneSoundManager.Swoosh();
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
	private void LookAtSelection(Transform objectTransform){
		if (zoomed) return;
		mainSceneSoundManager.MainClick();
		targetView = objectTransform;
		newFOV = 20;
		zoomed = true;
	}
	private void LookAway(){
		mainSceneSoundManager.MainClick();
		newFOV = 60;
		switch (viewPointNumber){
			case 1:
				GoToPosition1();
				break;
			case 2:
				GoToPosition2();
				break;
			case 3:
				GoToPosition3();
				break;
			default:
				throw new SwitchExpressionException();

		}
		zoomed = false;
	}
}
