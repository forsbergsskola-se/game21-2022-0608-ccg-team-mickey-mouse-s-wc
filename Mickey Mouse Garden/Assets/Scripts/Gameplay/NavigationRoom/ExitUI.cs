using UnityEngine;
using UnityEngine.Events;

public class ExitUI : MonoBehaviour{

	public UnityEvent exitUIEvent;
	public void EscapeUI(){
		exitUIEvent.Invoke();
		gameObject.SetActive(false);
	}
}
