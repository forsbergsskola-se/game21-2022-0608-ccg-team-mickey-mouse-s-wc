using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour {
	
	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown() {
		Debug.Log("Clicked!");
		
		UIChangedMessage uiChanged = new(){TaskToDo = 1, ObjectTransform = transform, ObjectTag = gameObject.tag};
		Broker.InvokeSubscribers(typeof(UIChangedMessage), uiChanged);
		
	}
}
