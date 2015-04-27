using UnityEngine;
using System.Collections;

public class GalagaSpaceship : MonoBehaviour {
	private const float RegenerateShieldDelay = 5f;
	private const float RegenerateShieldRate = 1f;
	private const float MaxThrottle = 40f;
	private const int DMG = 10;

	public float speed = 50f;
	public int healthpoint = 100;
	public int shield = 50;

	public int currentHP;
	public int currentShield;
	public bool isDead = false;
	public bool damaged = false;

	void Awake(){
		currentHP = healthpoint;
		currentShield = shield;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Fire(){
		Debug.Log ("Shots fire!");
	}

	public void Hit(){
		this.StopAllCoroutines ();
		damaged = true;

		if (currentShield > 0) {
			currentShield -= DMG;
		} else {
			currentHP -= DMG;
		}
		if (currentShield != shield) {
			StartCoroutine(ShieldDelay());
		}

		if(currentHP <= 0 && !isDead){
			//death function
		}
	}

	private IEnumerator ShieldDelay(){
		yield return new WaitForSeconds(RegenerateShieldDelay);
		StartCoroutine(RegenerateShield());
	}
	private IEnumerator RegenerateShield(){
		while (currentShield != shield) {
			currentShield += 10;
			yield return new WaitForSeconds (RegenerateShieldRate);
		}
	}	
}
