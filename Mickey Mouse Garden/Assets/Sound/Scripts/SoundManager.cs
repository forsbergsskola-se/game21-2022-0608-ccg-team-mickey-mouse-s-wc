using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  [Header("Impact")] public FMODUnity.EventReference ImpactEventReference;

  private FMOD.Studio.EventInstance impactInstance;


  [Header("Music")] public FMODUnity.EventReference GardenMusicEventReference;

  private FMOD.Studio.EventInstance gardenmusicInst;


  //[Header("UI")]




  void Start()
  {
    //music
    gardenmusicInst = FMODUnity.RuntimeManager.CreateInstance(GardenMusicEventReference);
    gardenmusicInst.start();

    //UI


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
