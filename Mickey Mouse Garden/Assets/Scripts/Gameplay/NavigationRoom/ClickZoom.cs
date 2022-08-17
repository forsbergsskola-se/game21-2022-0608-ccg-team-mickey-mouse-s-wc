using UnityEngine;

public class ClickZoom : MonoBehaviour{

	private bool canClick = true;
	private void OnEnable(){
		Broker.Subscribe<ClickBlockerMessage>(OnClickBlockerMessageReceived);
	}

	private void OnDisable(){
		Broker.Subscribe<ClickBlockerMessage>(OnClickBlockerMessageReceived);

	}
	private void OnClickBlockerMessageReceived(ClickBlockerMessage obj){
		canClick = !obj.UIActive;
	}
	private void OnMouseUp(){
		if (!canClick) return;
		UIChangedMessage uiChanged = new(){TaskToDo = 1, ObjectTransform = transform, ObjectTag = gameObject.tag};
		Broker.InvokeSubscribers(typeof(UIChangedMessage), uiChanged);
	}
}
