using UnityEngine;
using System.Collections;

public class RandomFiring : MonoBehaviour {

	public float BaseFireChance;
	public float FireChanceIncreaseRate;
	public float FireError;
	public Transform FirePoint;
	public GameObject Bullet;
	public Transform Player;

	private float currentChance;

	// Use this for initialization
	void Start () {
		currentChance = BaseFireChance;
		Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float num = Random.value;

		if(num <= currentChance)
		{
			Vector3 target = GenerateTarget();

			//Fire
			GameObject bullet = (GameObject) GameObject.Instantiate(Bullet, FirePoint.position, Quaternion.identity );
			bullet.GetComponent<EnemyBullet>().Target = target;
			currentChance = BaseFireChance;
		}
		else
			currentChance += FireChanceIncreaseRate;
	
	}

	//Add element of error to enemy shots
	Vector3 GenerateTarget()
	{
		Vector3 target = Player.position;
		float offness = Random.value * FireError;
		float sign = Random.value;
		if(sign >= 0.5f)
			target.x += offness;
		else
			target.x -= offness;
		
		offness = Random.value * FireError;
		sign = Random.value;
		if(sign >= 0.5f)
			target.z += offness;
		else
			target.z -= offness;
		
		offness = Random.value * FireError;
		sign = Random.value;
		if(sign >= 0.5f)
			target.z += offness;
		else
			target.z -= offness;

		return target;
	}
}
