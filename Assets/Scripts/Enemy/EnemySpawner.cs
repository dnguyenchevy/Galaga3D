﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] Enemies;
	public float[] Timings;
	public int[] waveDisplacements;
	private int waveIndex = 0;
	private int enemyIndex = 0;
	private bool waveSpawning = true;

	private int pathMin;
	private int pathMax;

	// Use this for initialization
	void Start () {
		if(gameObject.CompareTag("LeftSpawner"))
		{
			pathMin = 0;
			pathMax = 2;
		}
		else
		{
			pathMin = 2;
			pathMax = 4;
		}

		StartCoroutine(SpawningRoutine());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawningRoutine()
	{
		if(waveSpawning)
		{
			Debug.Log ("Spawning wave: "+waveIndex+" "+waveDisplacements.Length);
			while(enemyIndex < waveDisplacements[waveIndex])
			{
				Debug.Log("About to wait");
				yield return new WaitForSeconds(Timings[enemyIndex]);
				Debug.Log("Finished waiting");
				GameObject obj = (GameObject) GameObject.Instantiate(Enemies[enemyIndex], gameObject.transform.position, new Quaternion(0.5f, 0.5f, 0.5f, -0.5f));
				obj.GetComponent<Enemy>().AssignPath(pathMin, pathMax);
				enemyIndex++;
			}
			waveSpawning = false;
		}
		else if( GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && waveIndex < waveDisplacements.Length -1)
		{
			//Next wave incoming!!
			waveIndex++;
			waveSpawning = true;
		}
		else
			this.enabled = false;
	}
}
