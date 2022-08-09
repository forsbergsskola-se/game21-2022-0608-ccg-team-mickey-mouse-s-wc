using System;
using UnityEngine;

public class EnterTeamSelection : MonoBehaviour{

	[SerializeField] private GameObject confirmationBox, teamSelectCanvas, levelNotUnlockedBox;
	
	private bool shown;
	
	private void Awake(){
		Broker.Subscribe<UILockMessage>(OnUILockedMessageReceived);
	}
	private void OnUILockedMessageReceived(UILockMessage obj){
		shown = obj.Locked;
	}

	private void OnMouseDown() {
		if (GetComponent<MatchInformation>().isUnlocked && !shown) {
			confirmationBox.SetActive(true);
			LockUI(); 
			GetComponent<MatchInformation>().ConfirmTeam();
		} else if (!shown) {
			levelNotUnlockedBox.SetActive(true);
			LockUI();
		}
	}

	public void AcceptNotUnlocked() {
		levelNotUnlockedBox.SetActive(false);
		UnLockUI();
	}
	
	public void AnswerYes(){
		confirmationBox.SetActive(false);
		GoToTeamSelection();
	}

	public void AnswerNo(){
		confirmationBox.SetActive(false);
		UnLockUI();
	}
	
	private void GoToTeamSelection(){
		teamSelectCanvas.GetComponent<Canvas>().enabled = true;
	}

	private void LockUI(){
		UILockMessage uiLockMessage = new(){
			Locked = true
		};
		Broker.InvokeSubscribers(typeof(UILockMessage), uiLockMessage);
	}

	private void UnLockUI(){
		UILockMessage uiLockMessage = new(){
			Locked = false
		};
		Broker.InvokeSubscribers(typeof(UILockMessage), uiLockMessage);
	}

	private void OnDisable(){
		Broker.Unsubscribe<UILockMessage>(OnUILockedMessageReceived);
	}
}
