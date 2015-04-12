using UnityEngine;
using System.Collections;

public class GalagaSpaceship : MonoBehaviour {
	public float speed = .5f;
	public float healthpoint = 100f;
	public float shield = 100f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire(){
		Debug.Log ("Shots fire!");
	}
}
