using System.Collections;
using FMOD.Studio;
using UnityEngine;

public class MainSceneSoundManager : MonoBehaviour
{
  [Header("Music and Ambience")] 
  [SerializeField] private FMODUnity.EventReference ambientMusic, preCombatMusic;

  private EventInstance ambientMusicInstance, preCombatMusicInstance;
  
  public void PlayMusic(){
    ambientMusicInstance = FMODUnity.RuntimeManager.CreateInstance(ambientMusic);
    StartCoroutine(DelayMusicStart());
  }

  private IEnumerator DelayMusicStart(){
    yield return new WaitForSeconds(0.1f);
    ambientMusicInstance.start();
  }
  
  public void PlayPreCombatMusic(){
    preCombatMusicInstance = FMODUnity.RuntimeManager.CreateInstance(preCombatMusic);
    StartCoroutine(DelayPreCombatStart());
  }
  
  private IEnumerator DelayPreCombatStart(){
    yield return new WaitForSeconds(0.1f);
    preCombatMusicInstance.start();
  }
  
  public void PlantSeed() 
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/Garden/PlantSeeds");
  }

  public void MainClick() {
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/MainClick");
  }

  public void Purchase()
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/Market/Purchase");
  }
  
  public void Swoosh() { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Swosh");
  }

  public void Sell()
  {
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/Market/Sell");
  }
  
  public void Fusion(){
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/Garden/Fusion");
  }

  public void StopMusic(){
    ambientMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
  }
  
  public void PauseMusic(){
    ambientMusicInstance.setPaused(true);
  }
  
  public void UnPauseMusic(){
    ambientMusicInstance.setPaused(false);
  }
  
  public void StopPreCombatMusic(){
    if (preCombatMusicInstance.isValid()){
      preCombatMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
  }
  
  public void ModulateMusic(float distance){
    // Debug.Log(distance);
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Garden", distance);
  }

  public void ControlMusic(bool on) {
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MusicMain", @on ? 100 : 0);
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("AmbiMain", @on ? 100 : 0);
  }
  
  public void ControlSFX(bool on) {
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("UiMain", @on ? 100 : 0);
  }
  
  public void ControlAll(bool on) {
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MainSound", @on ? 0 : 100);
  }
}
