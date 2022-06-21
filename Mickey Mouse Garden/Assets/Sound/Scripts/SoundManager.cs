using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  [Header("Music and Ambience")] 
  public FMODUnity.EventReference GardenMusicEventReference;
  public FMODUnity.EventReference AmbienceEventReference;

  private FMOD.Studio.EventInstance gardenmusicInstance;
  private FMOD.Studio.EventInstance ambienceInstance; 

  //[Header("UI and Stuff")]
  //private FMOD.Studio.EventInstance ; 
  
  void Start()
  {
    //music
    gardenmusicInstance = FMODUnity.RuntimeManager.CreateInstance(GardenMusicEventReference);
    gardenmusicInstance.start();
    //ambience
    ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(AmbienceEventReference);
    ambienceInstance.start();

    


  }
  
  public void plantSeeds() 
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/PlantSeeds");
  }

  public void mainClick()
  {
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/MainClick");
  }


  public void purchase()
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Market/Purchase");
  }
  
  public void swosh()
  { 
    FMODUnity.RuntimeManager.PlayOneShot("event:/Meta/swosh");
  }
 
}






/*
// Update is called once per frame
void Update()
{   
}

public void StartEvent()
{
  myInstance.start();
}




public void SetParamByName()
{
  FMODUnity.RuntimeManager.StudioSystem.setParameterByName("InCar", 0);
}

  public void PlayKeycardPickUpSound()
{
  keycardPickUp = FMODUnity.RuntimeManager.CreateInstance(keycardPickUpPlaceEventHere);
  keycardPickUp.start();
  keycardPickUp.release();
}
*/
