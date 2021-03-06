﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GalagaSpaceship playership;
	private const float flashSpeed = 1f;
	private Color flashColour = new Color (1f, 0f, 0f, 0.1f);
	private GameData GD;

	public int currentLevel = 1;	//Current level the game is being played on
	public bool isPaused = false;

	public GameObject player;
	public GameObject PauseScreen;
	public Image damageImage;
	public Slider healthSlider;
	public Slider shieldSlider;

	public bool LeftSpawnerDone;
	public bool RightSpawnerDone;

	void Awake(){
		GD = GameObject.Find ("GameData").GetComponent<GameData> ();
	}

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Skybox> ().material = GD.selectedSkybox;

		playership = GameObject.FindGameObjectWithTag("Player").GetComponent<GalagaSpaceship> ();
		LeftSpawnerDone = false;
		RightSpawnerDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { //Paused Menu
			isPaused = !isPaused;
		}

		if(isPaused){
			pauseGame();
		}else{
			resumeGame ();
		}

		//Flash the screen to RED when getting hit
		if (playership.damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		playership.damaged = false;

		updateHUD();

		if(LeftSpawnerDone && RightSpawnerDone && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
		{
			Victory ();
		}
	}

	//UPDATE UI DATA
	private void updateHUD(){
		shieldSlider.value = playership.currentShield;
		healthSlider.value = playership.currentHP;
	}

	//Display PAUSE UI
	private void pauseGame(){
		//Set to active and displays Pause UI
		PauseScreen.SetActive(true);
		PauseScreen.GetComponent<CanvasGroup>().alpha = 1f;
		Time.timeScale = 0f;
	}

	//RESUME GAME and disable PAUSE UI
	public void resumeGame(){
		//Set PAUSE UI active to not display
		PauseScreen.SetActive(false);
		PauseScreen.GetComponent<CanvasGroup>().alpha = 0f;
		Time.timeScale = 1f;
	}

	public void Victory(){
		GD.status = true;
		Application.LoadLevel (2);
	}

	public void Lose(){
		GD.status = false;
		Application.LoadLevel (2);
	}
}
