using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	[SerializeField] private GameObject buttonLeft, buttonRight;
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;

	private void Awake() {
		pShop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		shop.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		shed.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		greenhouse.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
		arena.GetComponent<ClickZoom>().zoomChangedEvent.AddListener(DisableButton);
	}
	// Disables navigation buttons when zoomed in.
	private void DisableButton(Vector3 position, int zoomLevel, string clickName) {
		if (zoomLevel == 20) {
			buttonLeft.SetActive(false);
			buttonRight.SetActive(false);
		} else {
			buttonLeft.SetActive(true);
			buttonRight.SetActive(true);
		}
	}
}
