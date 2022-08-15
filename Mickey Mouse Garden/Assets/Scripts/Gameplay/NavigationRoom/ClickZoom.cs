using System;
using UnityEngine;
using UnityEngine.Events;

public class ClickZoom : MonoBehaviour{

	private bool canClick = true;
	private void OnEnable(){
		Broker.Subscribe<ClickBlockerMessage>(OnClickBlockerMessageReceived);
	}
	private void OnClickBlockerMessageReceived(ClickBlockerMessage obj){
		canClick = !obj.UIActive;
	}
	private void OnMouseUp() {
		if (canClick){
			UIChangedMessage uiChanged = new(){TaskToDo = 1, ObjectTransform = transform, ObjectTag = gameObject.tag};
			Broker.InvokeSubscribers(typeof(UIChangedMessage), uiChanged);
		}
	}
}
