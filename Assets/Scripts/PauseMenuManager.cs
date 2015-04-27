using UnityEngine;
using System.Collections;
//Pause Functionality

public class PauseMenuManager : MonoBehaviour {
	private const int MENU_SCENE = 0;
	private GameManager GM; 

	void Awake(){
		GM = GetComponent<GameManager> ();
	}

	public void ResumeGame(){
		GM.isPaused = !GM.isPaused;
	}
	
	public void RestartLevel(){
		Application.LoadLevel(GM.currentLevel);
	}
	
	public void QuitToMenu(){
		Application.LoadLevel(MENU_SCENE);
	}
	
	public void QuitToDesktop(){
		Application.Quit();
	}
}
