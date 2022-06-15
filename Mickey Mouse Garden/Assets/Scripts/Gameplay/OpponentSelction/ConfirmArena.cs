using UnityEngine;
using UnityEngine.Events;

public class ConfirmArena : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox;
	public UnityEvent<Vector3, int> opponentSelectedEvent;
	
	private bool shown;

	// Invokes event when object is clicked or touched (needs testing).
	private void OnMouseDown() {
		if (!shown){
			Debug.Log("Opponent!"); 
			confirmationBox.SetActive(true);
			shown = true;
		}
	}
}
