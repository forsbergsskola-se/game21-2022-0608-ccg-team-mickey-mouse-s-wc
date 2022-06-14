using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{
    public Canvas pauseMenu;

    public void Start(){
        pauseMenu.enabled = false;
    }
    public void Pause(){
        pauseMenu.enabled = true;
        Debug.Log("paused");
    }
    public void UnPause(){
        Debug.Log("unpaused");
        pauseMenu.enabled = false;
    }
}
