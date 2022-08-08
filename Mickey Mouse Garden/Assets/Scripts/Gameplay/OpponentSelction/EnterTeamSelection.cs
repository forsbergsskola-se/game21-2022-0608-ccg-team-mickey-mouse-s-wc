using UnityEngine;

public class EnterTeamSelection : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox, teamSelectCanvas;
	
	private bool shown;

	private void OnMouseDown() {
		confirmationBox.SetActive(true);
		shown = true;
		GetComponent<MatchInformation>().ConfirmTeam();
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
