using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	public GameObject buttonLeft, buttonRight;
	public GameObject pShop, shop, shed, greenHouse, arena;

	private void Awake(){
		pShop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		shop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		shed.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		greenHouse.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		arena.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
	}
	private void DisableButton(Vector3 position, int zoomLevel){
		if (zoomLevel == 20){
			buttonLeft.SetActive(false);
			buttonRight.SetActive(false);
		} else {
			buttonLeft.SetActive(true);
			buttonRight.SetActive(true);
		}
	}
}
