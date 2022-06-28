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
		Debug.Log("In answer yes");
		confirmationBox.SetActive(false);
		shown = false;
		GoToTeamSelection();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
		shown = false;
	}
	
	private void GoToTeamSelection(){
		Debug.Log("Should go to team selection");
		SceneManager.LoadScene("TeamSelection", LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("OpponentSelection");
	}
}
