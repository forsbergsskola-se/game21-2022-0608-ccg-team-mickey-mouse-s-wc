/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   [Header("Impact")]
   public FMODUnity.EventReference impactPlaceEventHere;
   
   private FMOD.Studio.EventInstance ImpactInstance;

   [Header("Music")]
   public FMODUnity.EventReference music;
   
   private FMOD.Studio.EventInstance musicInst;
   
   [Header("UI")]
   public FMODUnity.EventReference ;
   public FMODUnity.EventReference ;
   
   private FMOD.Studio.EventInstance ;
   private FMOD.Studio.EventInstance ;
   
   // Start is called before the first frame update
   void Start()
   {
       //music
       musicEvInst = FMODUnity.RuntimeManager.CreateInstance(musicInst);
       musicEvInst.start();
      
       //UI
       clickInstance = FMODUnity.RuntimeManager.CreateInstance(clickPlaceEventHere);
       keycardPickUp = FMODUnity.RuntimeManager.CreateInstance(keycardPickUpPlaceEventHere);

    
   }
   
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
