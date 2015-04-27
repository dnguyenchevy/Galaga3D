using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float Speed;
	public float Margin;
	public float FireError;
	public Vector3 Target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(Target == null)
			return;

		float distanceToGoal = Vector3.Distance(transform.position, Target);

		if(distanceToGoal <= Margin)
		{
			GameObject.Destroy(gameObject);
		}

		float distanceCovered = Speed * Time.deltaTime;
		float time = distanceCovered/distanceToGoal;
		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Target, time);
	}
}
