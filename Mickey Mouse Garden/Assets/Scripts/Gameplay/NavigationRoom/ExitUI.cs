using UnityEngine;

public class ExitUI : MonoBehaviour{

	private void Awake(){
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}
	
	private void OnUIChangedMessageReceived(UIChangedMessage obj){

		if (obj.TaskToDo == 2){
			gameObject.SetActive(false);
		}
	}
}
