using UnityEngine;

public class Billboard : MonoBehaviour {
    
	// For 2D sprites to face the camera.
    
	[SerializeField] private Camera camera;
	private void LateUpdate() {
		transform.forward = camera.transform.forward;
	}
}
