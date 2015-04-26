using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Charge : MonoBehaviour {

	public Transform[] Path;
	public Transform BackPoint;
	public Queue<Transform> MoveQueue;
	public float Margin;
	public float Speed;
	public Transform goal;

	private bool chargeFinished = false;


	// Use this for initialization
	void Start () {
		BackPoint = GameObject.FindGameObjectWithTag("BackPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(goal == null)
			return;

		if(chargeFinished)
		{
			gameObject.GetComponent<Dogfight>().enabled = true;
			this.enabled = false;
			return;
		}

		float distanceToGoal = Vector3.Distance(transform.position, goal.position);

		if(distanceToGoal <= Margin)
		{
			if(goal.Equals(BackPoint))
			{
				chargeFinished = true;
				return;
			}

			if(MoveQueue.Count > 0)
				goal = MoveQueue.Dequeue();
			else
				goal = BackPoint;

			distanceToGoal = Vector3.Distance(transform.position, goal.position);
		}

		float distanceCovered = Speed * Time.deltaTime;
		float time = distanceCovered/distanceToGoal;
		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, goal.position, time);
	}
}
