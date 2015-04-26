using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Material defaultSkybox;
	private int currentDirection = 0;
	
	void Start () {
		//Set the default Skybox for the camera
		this.GetComponent<Skybox>().material = defaultSkybox;

		this.StartCoroutine("changeRotation");
	}

	void Update () {

	}
	
	void FixedUpdate(){

		//Rotation cycle: right, down, left, up

		//Rotate right
		if(currentDirection == 0){
			this.transform.Rotate(new Vector3(0f, 5f * Time.deltaTime, 0f));
		}
		//Rotate down
		else if(currentDirection == 1){
			this.transform.Rotate(new Vector3(5f * Time.deltaTime, 0f, 0f));
		}
		//Rotate left
		else if(currentDirection == 2){
			this.transform.Rotate(new Vector3(0f, -5f * Time.deltaTime, 0f));
		}
		//Rotate up
		else{
			this.transform.Rotate(new Vector3(-5f * Time.deltaTime, 0f, 0f));
		}
	}

	//This method determines which direction the camera will rotate
	IEnumerator changeRotation(){

		while(true){
			//Reset the direction after one cycle
			if(currentDirection >= 3){
				currentDirection = 0;
			}
			//Change to the next direction
			else{
				currentDirection++;
			}

			//Wait 8 seconds before changing direction again
			yield return new WaitForSeconds(8f);
		}
	}

}
