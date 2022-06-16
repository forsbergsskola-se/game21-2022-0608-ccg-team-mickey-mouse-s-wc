using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour {

	public UnityEvent<Transform, string> selectedEvent;
	
	private bool selected;

	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown() {
		if (!selected){
			Debug.Log("Clicked!");
			selectedEvent.Invoke(transform, gameObject.tag);
			selected = true;
		} else {
			selectedEvent.Invoke(transform, gameObject.name);
			selected = false;
		}
	}
}
