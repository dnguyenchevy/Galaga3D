using UnityEngine;
using System.Collections;

public class GalagaSpaceship : MonoBehaviour {
	private const float RegenerateShieldDelay = 5f;
	private const float RegenerateShieldRate = 1f;
	private const float MaxThrottle = 40f;
	
	public float speed = 10f;
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

	public void Hit(int dmg){
		Debug.Log (string.Format ("[BEFORE]Current HP: {0} Current Shield: {1}", currentHP, currentShield));
		this.StopAllCoroutines ();
		damaged = true;

		if (currentShield > 0) {
			currentShield -= dmg;
		} else {
			currentHP -= dmg;
		}
		if (currentShield != shield) {
			StartCoroutine(ShieldDelay());
		}

		Debug.Log (string.Format ("[AFTER]Current HP: {0} Current Shield: {1}", currentHP, currentShield));
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
