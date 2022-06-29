using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTeamSelection : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox;
	
	private bool shown;

	private void OnMouseDown() {
		if (!shown) {
			confirmationBox.SetActive(true);
			shown = true;
			
		}
	}

	private IEnumerator LoadSceneAsync(){
		yield return new WaitForSeconds(0.1f); //TODO: change to be reactive
		GetComponent<Level>().ConfirmTeam();
		SceneManager.UnloadSceneAsync("OpponentSelection");
	}

	public void AnswerYes(){
		confirmationBox.SetActive(false);
		shown = false;
		GoToTeamSelection();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
		shown = false;
		SceneManager.UnloadSceneAsync("TeamSelection");
	}
	
	private void GoToTeamSelection(){
		SceneManager.LoadScene("TeamSelection", LoadSceneMode.Additive);
		StartCoroutine(LoadSceneAsync());
	}
}
