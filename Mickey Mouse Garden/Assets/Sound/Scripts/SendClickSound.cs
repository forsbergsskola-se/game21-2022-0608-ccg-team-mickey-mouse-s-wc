using UnityEngine;

public class SendClickSound : MonoBehaviour {
	public void ClickSound(){
		SoundClickMessage soundClickMessage = new();
		Broker.InvokeSubscribers(typeof(SoundClickMessage), soundClickMessage);
	}
}
