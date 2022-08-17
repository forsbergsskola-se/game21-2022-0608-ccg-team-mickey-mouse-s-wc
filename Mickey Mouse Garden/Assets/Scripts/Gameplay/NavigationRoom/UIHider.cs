using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	[SerializeField] private GameObject buttonLeft, buttonRight;
	
	private bool selected;

	private void Awake() {
		Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
	}

	private void OnUIChangedMessageReceived(UIChangedMessage obj){
		switch (obj.TaskToDo){
			case 1:
				DisableButton();
				break;
			case 2:
				EnableButton();
				break;
		}
	}

	// Disables navigation buttons when zoomed in.
	private void DisableButton(){
		if (selected) return;
		buttonLeft.SetActive(false);
		buttonRight.SetActive(false);
		selected = true;
	}
	private void EnableButton(){
		buttonLeft.SetActive(true);
		buttonRight.SetActive(true);
		selected = false;
	}
}
