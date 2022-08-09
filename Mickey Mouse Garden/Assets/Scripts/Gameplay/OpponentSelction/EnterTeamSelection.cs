using UnityEngine;

public class EnterTeamSelection : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox, teamSelectCanvas, levelNotUnlockedBox;
	
	private bool shown;

	private void OnMouseDown() {
		if (GetComponent<MatchInformation>().isUnlocked) {
			confirmationBox.SetActive(true);
			shown = true;
			GetComponent<MatchInformation>().ConfirmTeam();
		} else {
			levelNotUnlockedBox.SetActive(true);
		}
	}

	public void AcceptNotUnlocked() {
		levelNotUnlockedBox.SetActive(false);
	}
	
	public void AnswerYes(){
		confirmationBox.SetActive(false);
		GoToTeamSelection();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
	}
	
	private void GoToTeamSelection(){
		teamSelectCanvas.GetComponent<Canvas>().enabled = true;
	}
}
