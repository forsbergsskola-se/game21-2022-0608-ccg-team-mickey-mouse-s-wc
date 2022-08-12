using FMOD.Studio;
using UnityEngine;

public class MainSceneSoundManager : MonoBehaviour
{
  [Header("Music and Ambience")] 
  [SerializeField] private FMODUnity.EventReference ambientMusic, preCombatMusic;

  private EventInstance ambientMusicInstance, preCombatMusicInstance;
  
  
  public void PlayMusic(){
    ambientMusicInstance = FMODUnity.RuntimeManager.CreateInstance(ambientMusic);
    ambientMusicInstance.start();
  }
  public void PlayPreCombatMusic(){
    preCombatMusicInstance = FMODUnity.RuntimeManager.CreateInstance(preCombatMusic);
    preCombatMusicInstance.start();
  }
  public void PlantSeed() 
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/PlantSeeds");
  }

  public void MainClick() {
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/MainClick");
  }
  
  public void purchase()
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Market/Purchase");
  }
  
  public void Swoosh() { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Swosh");
  }

  public void sell()
  {
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Market/Sell");
  }

  public void Harvest()
  {
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/Market");
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
    preCombatMusicInstance.stop(STOP_MODE.ALLOWFADEOUT);
  }
  public void ModulateMusic(float distance){
    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Garden", distance);
  }
}
