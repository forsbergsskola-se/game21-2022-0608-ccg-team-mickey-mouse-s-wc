using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArena : MonoBehaviour {
	// Consider exiting directly outside the arena
	public void ExitToMenu(){
		SceneManager.LoadScene("NavigationRoom");
	}
}
