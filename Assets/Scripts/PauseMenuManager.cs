using UnityEngine;
using System.Collections;

public class PauseMenuManager : MonoBehaviour {
	private const int MENU_SCENE = 0;
	private GameManager GM; 

	void Awake(){
		Time.timeScale = 1;
		GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	public void ResumeGame(){
		GM.isPaused = false;
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
