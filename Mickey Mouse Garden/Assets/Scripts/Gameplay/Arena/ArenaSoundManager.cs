using System;
using FMOD.Studio;
using UnityEngine;

public class ArenaSoundManager : MonoBehaviour {
	[Header("Music and Ambience")] 
	// Choose in inspector
	[SerializeField] private FMODUnity.EventReference arenaBackground;
	// Reference to the event after it has started.
	private EventInstance arenaBackgroundInstance;

	private void Awake() {
		// Starts the music & attaches it to the InstanceReference
		arenaBackgroundInstance = FMODUnity.RuntimeManager.CreateInstance(arenaBackground);
		arenaBackgroundInstance.start();
	}

	public void Hit() { 
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Hits");
	}

	public void Faint(){
		Debug.Log("FaintSound");
	}
  
	public void Victory() { 
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Victory");
	}
  
	public void Defeat() { 
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Defeat");
	}
	
	public void Silence(){
		arenaBackgroundInstance.stop(STOP_MODE.ALLOWFADEOUT);
	}
}
