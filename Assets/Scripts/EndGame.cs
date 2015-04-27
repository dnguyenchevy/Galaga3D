using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text titleText;

	// Use this for initialization
	void Start () {
	
		this.GetComponent<Skybox>().material = GameObject.Find("GameData").GetComponent<GameData>().selectedSkybox;

		if(GameObject.Find("GameData").GetComponent<GameData>().status){
			titleText.text = "Victory";
		}
		else{
			titleText.text = "Game Over";
		}
	}

	//This function re-loads the game
	public void retryGame(){
		Application.LoadLevel(1);
	}

	//This function returns the player to the main menu
	public void returnToMainMenu(){
		Application.LoadLevel(0);
	}

	//This function closes the game
	public void quitGame(){
		Application.Quit();
	}
}
