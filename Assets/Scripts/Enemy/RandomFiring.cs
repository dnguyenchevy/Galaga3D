using UnityEngine;
using System.Collections;

public class RandomFiring : MonoBehaviour {

	public float BaseFireChance;
	public float FireChanceIncreaseRate;

	private float currentChance;

	// Use this for initialization
	void Start () {
		currentChance = BaseFireChance;
	
	}
	
	// Update is called once per frame
	void Update () {
		float num = Random.value;

		if(num <= currentChance)
		{
			//Fire
			currentChance = BaseFireChance;
		}
		else
			currentChance += FireChanceIncreaseRate;
	
	}
}
