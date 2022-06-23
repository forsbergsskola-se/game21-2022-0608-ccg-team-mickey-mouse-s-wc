using UnityEngine;

public class UIController : MonoBehaviour{
	public void ZoomOut(){
		UIChangedMessage uiChanged = new(){TaskToDo = 2};
		Broker.InvokeSubscribers(typeof(UIChangedMessage), uiChanged);
	}
}