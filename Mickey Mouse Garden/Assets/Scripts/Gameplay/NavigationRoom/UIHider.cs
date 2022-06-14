using UnityEngine;

public class UIHider : MonoBehaviour{

	public GameObject buttonLeft, buttonRight;
	public GameObject clickable1, clickable2, clickable3;

	private void Awake(){
		clickable1.GetComponent<ClickZoom>().zoomedInEvent.AddListener(DisableButton);
		clickable1.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(EnableButton);
		clickable2.GetComponent<ClickZoom>().zoomedInEvent.AddListener(DisableButton);
		clickable2.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(EnableButton);
		clickable3.GetComponent<ClickZoom>().zoomedInEvent.AddListener(DisableButton);
		clickable3.GetComponent<ClickZoom>().zoomedOutEvent.AddListener(EnableButton);
	}
	private void DisableButton(Vector3 position){
		buttonLeft.SetActive(false);
		buttonRight.SetActive(false);
	}

	private void EnableButton(){
		buttonLeft.SetActive(true);
		buttonRight.SetActive(true);
	}
}
