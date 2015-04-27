using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GalagaSpaceship playership;
	private const float flashSpeed = 1f;
	private Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	public int currentLevel = 0;
	public bool isPaused = false;

	public GameObject player;
	public Image damageImage;
	public Slider healthSlider;
	public Slider shieldSlider;

	public bool LeftSpawnerDone;
	public bool RightSpawnerDone;

	// Use this for initialization
	void Start () {
		playership = GameObject.FindGameObjectWithTag("Player").GetComponent<GalagaSpaceship> ();
		LeftSpawnerDone = false;
		RightSpawnerDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playership.damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		playership.damaged = false;

		updateHUD();

		if(LeftSpawnerDone && RightSpawnerDone && GameObject.FindGameObjectsWithTag("Enemy") <= 0)
		{
			//Victory
		}


	}

	private void updateHUD(){
		shieldSlider.value = playership.currentShield;
		healthSlider.value = playership.currentHP;
	}
}
