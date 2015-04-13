using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	private const float ROTATION_AMOUNT = 10f;
	private float targetAngle = 0f;
	private GalagaSpaceship spacecraft;
	
	public GameObject player;
	public GameObject turret;
	public Camera camera;

	//Test comment

	void Start(){
		spacecraft = GetComponent<GalagaSpaceship> ();
	}
	
	void Update(){
		// Trigger functions if Rotate is requested
		if (Input.GetKeyDown(KeyCode.LeftArrow)) { //Move camera & turret clockwise
			targetAngle -= 90.0f;
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) { //Move camera & turret counter-clockwise
			targetAngle += 90.0f;
		}

		if (Input.GetKeyDown (KeyCode.Space)) { //Turret shooting function
			spacecraft.Fire();
		}

		if (targetAngle != 0) {
			Rotate();
		}

		//Spaceship movement WASD
		if (Input.GetKey (KeyCode.W)) { //Forward movement
			GetComponent<Transform> ().Translate (Vector3.forward * spacecraft.speed * Time.deltaTime);
		}else if (Input.GetKey (KeyCode.A)) { //Left movement
			GetComponent<Transform> ().Translate (Vector3.left * spacecraft.speed * Time.deltaTime);
		}else if (Input.GetKey (KeyCode.S)) { //Backward movement
			GetComponent<Transform> ().Translate (Vector3.back * spacecraft.speed * Time.deltaTime);
		}else if (Input.GetKey (KeyCode.D)) { //Right movement
			GetComponent<Transform> ().Translate (Vector3.right * spacecraft.speed * Time.deltaTime);
		}

		//Spaceship movement vertical Up/Down Arrow
		if (Input.GetKey (KeyCode.UpArrow)) { //Upward movement
			GetComponent<Transform> ().Translate (Vector3.up * spacecraft.speed * Time.deltaTime);
		}else if (Input.GetKey (KeyCode.DownArrow)) { //Downward movement
			GetComponent<Transform> ().Translate (Vector3.down * spacecraft.speed * Time.deltaTime);
		}
	}
	
	protected void Rotate(){
		if (targetAngle > 0){ //Rotate counter-clockwise around player
			camera.GetComponent<Transform>().RotateAround(player.GetComponent<Transform>().position, Vector3.up, -ROTATION_AMOUNT);
			turret.GetComponent<Transform>().RotateAround(turret.GetComponent<Transform>().position, Vector3.up, -ROTATION_AMOUNT);
			targetAngle -= ROTATION_AMOUNT;
		}else if(targetAngle < 0){ //Rotate clockwise around player
			camera.GetComponent<Transform>().RotateAround(player.GetComponent<Transform>().position, Vector3.up, ROTATION_AMOUNT);
			turret.GetComponent<Transform>().RotateAround(turret.GetComponent<Transform>().position, Vector3.up, ROTATION_AMOUNT);
			targetAngle += ROTATION_AMOUNT;
		}
	}
}
