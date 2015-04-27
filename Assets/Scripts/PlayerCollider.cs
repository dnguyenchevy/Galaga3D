using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	//Player has been hit by an object
	void OnTriggerEnter(Collider collision){
		gameObject.GetComponentInParent<GalagaSpaceship> ().Hit ();
	}
}
