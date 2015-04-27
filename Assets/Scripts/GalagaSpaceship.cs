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

	public GameObject Bullet;
	public GameObject FirePoint;
	public Transform target;

	void Awake(){
		currentHP = healthpoint;
		currentShield = shield;
	}

	public void Fire(){
		GameObject bullet = (GameObject) GameObject.Instantiate(Bullet, FirePoint.GetComponent<Transform>().position, Quaternion.identity );
		bullet.GetComponent<EnemyBullet>().Target = target.position;

		bullet.transform.LookAt (target);
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
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Lose ();
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
