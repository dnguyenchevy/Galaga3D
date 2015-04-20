using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[][] Enemies;
	public float[][] Timings;
	private int waveIndex = 0;
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
			for(int i = 0; i < Enemies[waveIndex].Length; i++)
			{
				yield return new WaitForSeconds(Timings[waveIndex][i]);
				GameObject obj = GameObject.Instantiate(Enemies[waveIndex][i]);
				obj.GetComponent<Enemy>().AssignPath(pathMin, pathMax);
			}
			waveSpawning = false;
		}
		else if( GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && waveIndex < Enemies.Length -1)
		{
			//Next wave incoming!!
			waveIndex++;
			waveSpawning = true;
		}
		else
			this.enabled = false;
	}
}
