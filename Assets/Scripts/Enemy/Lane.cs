using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lane : MonoBehaviour {

	public int Count {
		get
		{
			return Enemies.Count;
		}
	}
	public List<GameObject> Enemies;
	public float AnchorDistance;

	public Transform RoutePoint;

	private Vector3 nextAnchor;

	// Use this for initialization
	void Start () {
		Enemies = new List<GameObject>();
		nextAnchor = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddEnemy(GameObject enemy)
	{
		enemy.GetComponent<Dogfight>().DogFightPosition = nextAnchor;
		enemy.GetComponent<Dogfight>().LaneIndex = Enemies.Count;
		nextAnchor.z += AnchorDistance;
		Enemies.Add(enemy);
	}

	public void RemoveEnemy(int index)
	{
		nextAnchor.z -= AnchorDistance;
		for(int i = index+1; i < Enemies.Count; i++)
		{
			Enemies[i].GetComponent<Dogfight>().DogFightPosition.z -= AnchorDistance;
		}
		Enemies.RemoveAt(index);
	}
}
