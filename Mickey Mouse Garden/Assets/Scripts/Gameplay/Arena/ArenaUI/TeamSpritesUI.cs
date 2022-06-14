using UnityEngine;
using Image = UnityEngine.UIElements.Image;

public class TeamSpritesUI : MonoBehaviour{
	public GameObject activeFighter1, portrait1;
	private void Start(){
		portrait1.GetComponent<UnityEngine.UI.Image>().sprite = activeFighter1.GetComponent<PlayerFighterSimulator>().sprite;
	}
}
