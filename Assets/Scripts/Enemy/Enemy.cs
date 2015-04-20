using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

	public EnemyClass Class;
	public Transform[] Path1;
	public Transform[] Path2;
	public Transform[] Path3;
	public Transform[] Path4;

	private Dogfight dogFight;

	// Use this for initialization
	void Start () {
		dogFight = gameObject.GetComponent<Dogfight>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("PlayerBullet"))
		{
			//Play death animation

			if(dogFight.enabled == true)
			{
				dogFight.MyLane.RemoveEnemy(dogFight.LaneIndex);
			}
		}
	}

	public void AssignPath(int min, int max)
	{
		Charge charge = gameObject.GetComponent<Charge>();

		System.Random rng = new System.Random();
		int path = rng.Next(min, max);
		if(path == 0)
			charge.Path = Path1;
		else if(path == 1)
			charge.Path = Path2;
		else if(path == 2)
			charge.Path = Path3;
		else
			charge.Path = Path4;
	}
}
public enum EnemyClass
{
	SOLDIER,
	COMMANDER
};