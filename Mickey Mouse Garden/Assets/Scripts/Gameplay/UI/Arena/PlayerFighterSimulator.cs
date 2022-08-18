using UnityEngine;
using UnityEngine.Events;

public class PlayerFighterSimulator : MonoBehaviour{
	public bool isAlive = true;
	public bool isActive;
	public Sprite sprite;

	public UnityEvent<string> playerDedEvent, playerActiveEvent;
	
	private void Update(){
		if (!isAlive){
			playerDedEvent?.Invoke(gameObject.tag);
			isActive = false;
		}
		if (isActive){
			playerActiveEvent?.Invoke(gameObject.tag);
		}
	}
}
