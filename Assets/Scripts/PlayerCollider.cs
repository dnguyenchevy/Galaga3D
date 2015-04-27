using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	//Player has been hit by an object
	void OnTriggerEnter(Collider collision){
		if (!collision.gameObject.CompareTag ("PlayerBullet")) {
			Debug.Log ("I've been hit!");
			gameObject.GetComponentInParent<GalagaSpaceship> ().Hit ();
		}
	}
}
