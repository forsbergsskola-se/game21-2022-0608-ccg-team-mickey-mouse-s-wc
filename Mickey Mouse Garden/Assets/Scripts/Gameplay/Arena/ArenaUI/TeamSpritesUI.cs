using UnityEngine;

public class TeamSpritesUI : MonoBehaviour{
	public GameObject activeFighter1, portrait1, activeFighter2, portrait2, activeFighter3, portrait3;
	private void Start(){
		portrait1.GetComponent<UnityEngine.UI.Image>().sprite = activeFighter1.GetComponent<PlayerFighterSimulator>().sprite;
		portrait2.GetComponent<UnityEngine.UI.Image>().sprite = activeFighter2.GetComponent<PlayerFighterSimulator>().sprite;
		portrait3.GetComponent<UnityEngine.UI.Image>().sprite = activeFighter3.GetComponent<PlayerFighterSimulator>().sprite;

	}
}
