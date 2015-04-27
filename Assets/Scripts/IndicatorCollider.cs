using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorCollider : MonoBehaviour {
	private const int NUM_FLASHES = 4;
	private const float flashTime = .5f;

	public RawImage img;

	//GameObject that is not the player within the Trigger, Flash directional indicator
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.name != "SpaceshipShell") {
			StartCoroutine (flashIndicator ());
		}
	}

	//Animate RawImage to flash a particular amount of time
	private IEnumerator flashIndicator(){
		for (int count = 0; count < NUM_FLASHES; count++) {
			img.enabled = true;
			yield return new WaitForSeconds(flashTime);

			img.enabled = false;
			yield return new WaitForSeconds(flashTime);
		}
	}
}
