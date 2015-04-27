using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class Dogfight : MonoBehaviour {

	public Vector3 DogFightPosition;
	public float Margin;
	public float Speed;

	private Lane rightLane;
	private Lane backLane;
	private Lane leftLane;

	public Lane MyLane;
	public int LaneIndex;
	private Vector3 route;
	private bool routing = true;

	// Use this for initialization
	void Start () 
	{
		rightLane = GameObject.FindGameObjectWithTag("RightLane").GetComponent<Lane>();
		backLane = GameObject.FindGameObjectWithTag("BackLane").GetComponent<Lane>();
		leftLane = GameObject.FindGameObjectWithTag("LeftLane").GetComponent<Lane>();

		AssignLane();

		MyLane.AddEnemy(gameObject);

		route = MyLane.RoutePoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(routing)
		{
			float distanceToGoal = Vector3.Distance(transform.position, route);
			
			if(distanceToGoal > Margin)
			{
				gameObject.transform.LookAt(route);
				float distanceCovered = Speed * Time.deltaTime;
				float time = distanceCovered/distanceToGoal;
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, route, time);
			}
			else
				routing = false;
		}
		else
		{
			float distanceToGoal = Vector3.Distance(transform.position, DogFightPosition);
			
			if(distanceToGoal > Margin)
			{
				gameObject.transform.LookAt(DogFightPosition);
				float distanceCovered = Speed * Time.deltaTime;
				float time = distanceCovered/distanceToGoal;
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, DogFightPosition, time);
			}
			else
			{
				Vector3 lookAt = transform.position;
				lookAt.z += 100;
				transform.LookAt(lookAt);
			}

		}

	
	}

	void AssignLane()
	{
		int[] counts = {rightLane.Count, backLane.Count, leftLane.Count};
		int min = counts.Min();
		List<int> possibilities = new List<int>();
		for(int i = 0; i < 3; i++)
		{
			if(counts[i] == min)
				possibilities.Add (i);
		}

		System.Random rng = new System.Random();
		int assignment = possibilities[rng.Next(0, possibilities.Count)];

		if(assignment == 0)
			MyLane = rightLane;
		else if(assignment == 1)
			MyLane = backLane;
		else
			MyLane = leftLane;
	}
}
