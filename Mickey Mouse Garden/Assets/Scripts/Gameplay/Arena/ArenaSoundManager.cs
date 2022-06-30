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
	
	// Rock = 1, Paper = 2, Scissors = 3. Rarity 1 to 4. Not implemented.
	public void Hit(float damageDealt, string alignment, string rarity){
		FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("RockPaperScissor", alignment);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("Rarity", rarity);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Damage", damageDealt);
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
	public void ModulateMusic(int delta){
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Delta", delta);
	}
}
