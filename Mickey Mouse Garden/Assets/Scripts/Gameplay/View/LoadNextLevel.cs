using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
   public void Continue(){
      SceneManager.UnloadSceneAsync("Arena");
   }
}
