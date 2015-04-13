using UnityEngine;
using System.Collections;

public class GalagaSpaceship : MonoBehaviour {
	private const float MaxThrottle = 40f;
	
	public float speed = 10f;
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
