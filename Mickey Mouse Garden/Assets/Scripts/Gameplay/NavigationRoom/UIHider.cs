using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	[SerializeField] private GameObject buttonLeft, buttonRight;
	
	private bool selected;

	private void Awake() {
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnUIChangedMessageReceived(UIChangedMessage obj){
		if (obj.TaskToDo == 1){
			DisableButton();
		}
		if (obj.TaskToDo == 2){
			EnableButton();
		}
	}

	// Disables navigation buttons when zoomed in.
	private void DisableButton(){
		if (!selected){
			buttonLeft.SetActive(false);
			buttonRight.SetActive(false);
			selected = true;
		}
	}
	private void EnableButton(){
		buttonLeft.SetActive(true);
		buttonRight.SetActive(true);
		selected = false;
	}
}
