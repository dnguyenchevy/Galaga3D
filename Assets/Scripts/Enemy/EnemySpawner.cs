using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] Enemies;
	public float[] Timings;
	public int[] waveDisplacements;
	private int waveIndex = 0;
	private int enemyIndex = 0;
	private bool waveSpawning = true;
	private GameManager GM;

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
		GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		StartCoroutine(SpawningRoutine());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawningRoutine()
	{
		if(waveSpawning)
		{
			while(enemyIndex < waveDisplacements[waveIndex])
			{
				yield return new WaitForSeconds(Timings[enemyIndex]);
				GameObject obj = (GameObject) GameObject.Instantiate(Enemies[enemyIndex], gameObject.transform.position, Quaternion.identity);
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
		{
			if(gameObject.CompareTag("LeftSpawner"))
				GM.LeftSpawnerDone = true;
			else
				GM.RightSpawnerDone = true;
				
			this.enabled = false;
		}
	}
}
