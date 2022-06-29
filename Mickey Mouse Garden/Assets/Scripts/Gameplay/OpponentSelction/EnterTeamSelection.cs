using UnityEngine;

public class EnterTeamSelection : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox, teamSelect;
	
	private bool shown;

	private void OnMouseDown() {
		confirmationBox.SetActive(true);
		shown = true;
		GetComponent<Level>().ConfirmTeam();
	}
	
	public void AnswerYes(){
		confirmationBox.SetActive(false);
		GoToTeamSelection();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
	}
	
	private void GoToTeamSelection(){
		teamSelect.GetComponent<Canvas>().enabled = true;
	}
}
