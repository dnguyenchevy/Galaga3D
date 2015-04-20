using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Charge : MonoBehaviour {

	public Transform[] Path;
	public Transform BackPoint;
	private Queue<Transform> moveQueue;
	public float Margin;
	public float Speed;

	private Transform goal;
	private bool chargeFinished = false;


	// Use this for initialization
	void Start () {
		moveQueue = new Queue<Transform>(Path);
		goal = moveQueue.Dequeue();
	}
	
	// Update is called once per frame
	void Update () {
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

			if(moveQueue.Count > 0)
				goal = moveQueue.Dequeue();
			else
				goal = BackPoint;

			distanceToGoal = Vector3.Distance(transform.position, goal.position);
		}

		float time = distanceToGoal/Speed;
		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, goal.position, time);
	}
}
