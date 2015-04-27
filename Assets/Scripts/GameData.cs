using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	//Instance of the object
	public static GameData Instance
	{
		get{ return instance; }
		set{}
	}
	
	private static GameData instance = null;

	//Determine whether or not the object already exists
	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			DestroyImmediate(this.gameObject);
		}
	}

	//The selected Skybox from the Menu scene
	public Material selectedSkybox{get; set;}

	//Used to determine win or lose
	public bool status{get; set;}
}
