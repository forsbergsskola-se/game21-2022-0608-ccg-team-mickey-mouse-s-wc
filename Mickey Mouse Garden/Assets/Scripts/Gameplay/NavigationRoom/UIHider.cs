using UnityEngine;

// Disables navigation buttons when zoomed into store or feature. May discard if navigation arrows are in world space.
public class UIHider : MonoBehaviour {

	[SerializeField] private GameObject buttonLeft, buttonRight;
	
	[SerializeField] private GameObject pShop, shop, shed, greenhouse, arena;
	[SerializeField] private GameObject pShopUI, shopUI, shedUI, greenhouseUI;


	private bool selected;

	private void Awake() {
		pShop.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		shop.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		shed.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		greenhouse.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		arena.GetComponent<ClickZoom>().selectedEvent.AddListener(DisableButton);
		
		pShopUI.GetComponent<ExitUI>().exitUIEvent.AddListener(EnableButton);
		shopUI.GetComponent<ExitUI>().exitUIEvent.AddListener(EnableButton);
		shedUI.GetComponent<ExitUI>().exitUIEvent.AddListener(EnableButton);
		greenhouseUI.GetComponent<ExitUI>().exitUIEvent.AddListener(EnableButton);
	}
	// Disables navigation buttons when zoomed in.
	private void DisableButton(Transform objectTransform, string clickName){
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
