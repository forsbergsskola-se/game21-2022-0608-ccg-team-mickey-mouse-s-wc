using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	[SerializeField] private GameObject buttonLeft, buttonRight;
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;

	private bool selected;

	private void Awake() {
		pShop.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		shop.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		shed.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		greenhouse.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		arena.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
	}
	// Disables navigation buttons when zoomed in.
	private void DisableButton(Transform objectTransform, string clickName) {
		if (!selected) {
			buttonLeft.SetActive(false);
			buttonRight.SetActive(false);
			selected = true;
		} else {
			buttonLeft.SetActive(true);
			buttonRight.SetActive(true);
			selected = false;
		}
	}
}
