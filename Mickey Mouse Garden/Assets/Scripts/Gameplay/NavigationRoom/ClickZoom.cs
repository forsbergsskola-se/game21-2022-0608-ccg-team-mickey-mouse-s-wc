using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour {

	public UnityEvent<Transform, string> selectedEvent;
	
	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown() {
		Debug.Log("Clicked!");
		selectedEvent.Invoke(transform, gameObject.tag);
	}
}
