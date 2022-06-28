using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnterTeamSelection : MonoBehaviour{

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
	
	private void GoToArena(){
		SceneManager.LoadScene("TeamSelection", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("OpponentSelection");
	}
}
