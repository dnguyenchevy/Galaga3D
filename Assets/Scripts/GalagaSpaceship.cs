﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalagaSpaceship : MonoBehaviour {
	private const float RegenerateShieldDelay = 5f;
	private const float RegenerateShieldRate = 1f;
	private const float MaxThrottle = 40f;
	private const float flashSpeed = 1f;
	private Color flashColour = new Color (1f, 0f, 0f, 0.1f);
	
	public float speed = 10f;
	public int healthpoint = 100;
	public int shield = 50;
	public Image damageImage;
	public Slider healthSlider;
	public Slider shieldSlider;

	private int currentHP;
	private int currentShield;
	private bool isDead = false;
	private bool damaged = false;

	void Awake(){
		currentHP = healthpoint;
		currentShield = shield;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
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
		updateHUD();

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
			updateHUD();
			yield return new WaitForSeconds(RegenerateShieldRate);
		}
	}

	private void updateHUD(){
		shieldSlider.value = currentShield;
		healthSlider.value = currentHP;
	}

}
