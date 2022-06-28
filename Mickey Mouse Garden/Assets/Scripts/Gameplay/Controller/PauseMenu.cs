using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public Canvas pauseMenu;
    public Canvas pauseButton;

    public void Start(){
        pauseMenu.enabled = false;
    }
    public void Pause(){
        pauseMenu.enabled = true;
        pauseButton.enabled = false;
    }
    public void UnPause(){
        pauseButton.enabled = true;
        pauseMenu.enabled = false;
    }
    public void GoToMarket(){
        SceneManager.LoadScene("Market");
    }
    public void MainMenu(){
        SceneManager.UnloadSceneAsync("Arena");
    }
    public void QuitNow(){
        Application.Quit();
    }
}
