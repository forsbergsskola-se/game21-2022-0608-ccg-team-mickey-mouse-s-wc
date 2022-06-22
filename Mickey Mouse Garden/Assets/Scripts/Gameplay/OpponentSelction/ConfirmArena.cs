using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ConfirmArena : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox;
	
	private bool shown;

	private void OnMouseDown() {
		if (!shown) {
			Debug.Log("Opponent!"); 
			confirmationBox.SetActive(true);
			shown = true;
		}
	}

	public void AnswerYes(){
		confirmationBox.SetActive(false);
		shown = false;
		GoToArena();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
		shown = false;
	}

	// TODO: Change to teambuilding scene
	private void GoToArena(){
		SceneManager.LoadScene("Arena");
	}
}
