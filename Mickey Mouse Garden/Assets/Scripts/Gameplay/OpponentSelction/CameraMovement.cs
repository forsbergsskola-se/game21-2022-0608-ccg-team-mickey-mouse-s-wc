using UnityEngine;

public class CameraMovement : MonoBehaviour{
	
	[SerializeField] private float cameraMoveSpeed;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 targetPosition;
	

	private void Awake(){
		targetPosition = transform.position;
	}
	private void Update() {
		var position = transform.position;
		position = Vector3.SmoothDamp(position, targetPosition, ref velocity, cameraMoveSpeed);
		transform.position = position;
	}
	public void StepForward() {
		targetPosition += new Vector3(0, 0, 5);
	}
	public void StepBackward() {
		targetPosition -= new Vector3(0, 0, 5);
	}
}
