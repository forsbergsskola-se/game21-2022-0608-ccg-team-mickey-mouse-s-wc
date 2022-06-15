using UnityEngine;

// Disables navigation buttons when zoomed into store or feature.
public class UIHider : MonoBehaviour{

	public GameObject buttonLeft, buttonRight;
	public GameObject clickable1, clickable2, clickable3;

	private void Awake(){
		clickable1.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		clickable2.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		clickable3.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
	}
	private void DisableButton(Vector3 position, int zoomLevel){
		if (zoomLevel == 20){
			buttonLeft.SetActive(false);
			buttonRight.SetActive(false);
		}
		else{
			buttonLeft.SetActive(true);
			buttonRight.SetActive(true);
		}
	}
}
