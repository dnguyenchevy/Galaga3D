using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	void OnTriggerEnter(Collider collision){
		Debug.Log ("You've hit something Jimmy!");
		gameObject.GetComponentInParent<GalagaSpaceship> ().Hit ();
	}
}
