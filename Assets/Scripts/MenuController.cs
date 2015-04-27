﻿using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Material skybox1;
	public Material skybox2;
	public Material skybox3;
	public Material skybox4;
	public Material skybox5;

	public GameObject controlPanel;
	public GameObject backgroundPanel;

	private int currentDirection = 0;
	private bool controlPanelDisplay = true;
	private bool backgroundPanelDisplay = false;

	void Start () {
		//Set the default Skybox for the camera
		this.GetComponent<Skybox>().material = skybox1;

		backgroundPanel.SetActive(backgroundPanelDisplay);
		this.StartCoroutine("changeRotation");
	}

	void Update () {

	}
	
	void FixedUpdate(){

		//Rotation cycle: right, down, left, up

		//Rotate right
		if(currentDirection == 0){
			this.transform.Rotate(new Vector3(0f, 5f * Time.deltaTime, 0f));
		}
		//Rotate down
		else if(currentDirection == 1){
			this.transform.Rotate(new Vector3(5f * Time.deltaTime, 0f, 0f));
		}
		//Rotate left
		else if(currentDirection == 2){
			this.transform.Rotate(new Vector3(0f, -5f * Time.deltaTime, 0f));
		}
		//Rotate up
		else{
			this.transform.Rotate(new Vector3(-5f * Time.deltaTime, 0f, 0f));
		}
	}

	//This method determines which direction the camera will rotate
	IEnumerator changeRotation(){

		while(true){
			//Reset the direction after one cycle
			if(currentDirection >= 3){
				currentDirection = 0;
			}
			//Change to the next direction
			else{
				currentDirection++;
			}

			//Wait 8 seconds before changing direction again
			yield return new WaitForSeconds(8f);
		}
	}

	//Write the Play game method

	//This function will display the options menu
	public void displayOptionsCanvas(){
		Canvas mainMenuCanvas = GameObject.FindGameObjectWithTag("MainMenuCanvas").GetComponent<Canvas>();
		Canvas optionsCanvas = GameObject.FindGameObjectWithTag("OptionsCanvas").GetComponent<Canvas>();

		if(!optionsCanvas.enabled){
			mainMenuCanvas.enabled = false;
			optionsCanvas.enabled = true;
		}
	}

	//This function will close the game
	public void quitGame(){
		Application.Quit();
	}

	//This function will display the control panel
	public void displayControlPanel(){

		if(!controlPanelDisplay){
			backgroundPanelDisplay = false;
			backgroundPanel.SetActive(backgroundPanelDisplay);

			controlPanelDisplay = !controlPanelDisplay;
			controlPanel.SetActive(true);
		}
	}

	//This function will display the background panel
	public void displayBackgroundPanel(){

		if(!backgroundPanelDisplay){
			controlPanelDisplay = false;
			controlPanel.SetActive(controlPanelDisplay);

			backgroundPanelDisplay = !backgroundPanelDisplay;
			backgroundPanel.SetActive(backgroundPanelDisplay);
		}
	}
	
	//This function will display the main menu
	public void displayMainMenuCanvas(){
		Canvas optionsCanvas = GameObject.FindGameObjectWithTag("OptionsCanvas").GetComponent<Canvas>();
		Canvas mainMenuCanvas = GameObject.FindGameObjectWithTag("MainMenuCanvas").GetComponent<Canvas>();

		if(!mainMenuCanvas.enabled){
			optionsCanvas.enabled = false;
			mainMenuCanvas.enabled = true;
		}
	}

}
