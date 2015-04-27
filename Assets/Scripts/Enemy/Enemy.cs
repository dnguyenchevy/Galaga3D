using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Enemy : MonoBehaviour {

	public EnemyClass Class;

	private Dogfight dogFight;
	public PathManager PM;

	// Use this for initialization
	void Start () {
		dogFight = gameObject.GetComponent<Dogfight>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player"))
		{
			//Play death animation
			GameObject.Destroy(gameObject);

			if(dogFight.enabled == true)
			{
				dogFight.MyLane.RemoveEnemy(dogFight.LaneIndex);
			}
		}
	}

	public void AssignPath(int min, int max)
	{
		Charge charge = gameObject.GetComponent<Charge>();
		PM = GameObject.FindGameObjectWithTag("PM").GetComponent<PathManager>();

		System.Random rng = new System.Random();
		int path = rng.Next(min, max);
		if(Class == EnemyClass.COMMANDER)
		{
			if(path == 0)
				charge.Path = PM.CommPath1;
			else if(path == 1)
				charge.Path = PM.CommPath2;
			else if(path == 2)
				charge.Path = PM.CommPath1Rev;
			else
				charge.Path = PM.CommPath2Rev;
		}
		else if(Class == EnemyClass.SOLDIER)
		{
			if(path == 0)
				charge.Path = PM.SoldPath1;
			else if(path == 1)
				charge.Path = PM.SoldPath2;
			else if(path == 2)
				charge.Path = PM.SoldPath1Rev;
			else
				charge.Path = PM.SoldPath2Rev;
		}
		charge.MoveQueue = new Queue<Transform>(charge.Path);
		charge.goal = charge.MoveQueue.Dequeue();
	}
}
public enum EnemyClass
{
	SOLDIER,
	COMMANDER
};