using System.Collections;
using FMOD.Studio;
using UnityEngine;

public class ArenaSoundManager : MonoBehaviour {
	[Header("Music and Ambience")] 
	// Choose in inspector
	[SerializeField] private FMODUnity.EventReference arenaBackground;
	// Reference to the event after it has started.
	private EventInstance arenaBackgroundInstance;

	// Starts the music & attaches it to the InstanceReference
	public void PlayMusic(){
		arenaBackgroundInstance = FMODUnity.RuntimeManager.CreateInstance(arenaBackground);
		StartCoroutine(DelayMusicStart());
	}
	private IEnumerator DelayMusicStart(){
		yield return new WaitForSeconds(0.1f);
		arenaBackgroundInstance.start();
	}
	
	// Rock = 1, Paper = 2, Scissors = 3. Rarity 1 to 4. Not implemented.
	public void Hit(string alignment, int rarity){
		FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("RockPaperScissor", alignment);
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Rarity", rarity * 0.1f);
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Hits");
	}

	public void Victory() { 
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Victory");
	}
  
	public void Defeat() { 
		FMODUnity.RuntimeManager.PlayOneShot("event:/Arena/Defeat");
	}
	
	public void StopMusic(){
		arenaBackgroundInstance.stop(STOP_MODE.ALLOWFADEOUT);
	}
	public void ModulateMusic(int delta){
		// FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Delta", delta);
	}
}
