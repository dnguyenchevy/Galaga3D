using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorCollider : MonoBehaviour {
	private const int NUM_FLASHES = 4;
	private const float flashTime = .5f;

	public RawImage img;

	void OnTriggerEnter(Collider coll){
		StartCoroutine (flashIndicator());
	}

	private IEnumerator flashIndicator(){
		for (int count = 0; count < NUM_FLASHES; count++) {
			img.enabled = true;
			yield return new WaitForSeconds(flashTime);

			img.enabled = false;
			yield return new WaitForSeconds(flashTime);
		}
	}
}
