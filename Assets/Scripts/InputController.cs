using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	private const float ROTATION_AMOUNT = 10f;

	private float targetAngle = 0f;
	private GalagaSpaceship spacecraft;


	public GameObject player;
	public GameObject turret;
	public GameObject CenterPoint;
	public GameObject indicator;
	public new Camera camera;
	public Transform GM;
	public float CloseBoundary;
	public float FarBoundary;

	void Start(){
		spacecraft = GetComponent<GalagaSpaceship> ();
	}
	
	void Update(){
		if (!GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().isPaused) {
			// Trigger functions if Rotate is requested
			if (Input.GetKeyDown (KeyCode.LeftArrow)) { //Move camera & turret clockwise
				targetAngle -= 90.0f;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) { //Move camera & turret counter-clockwise
				targetAngle += 90.0f;
			}

			if (Input.GetKeyDown (KeyCode.Space)) { //Turret shooting function
				spacecraft.Fire ();
			}

			if (targetAngle != 0) {
				Rotate ();
			}

			//Spaceship movement WASD
			if (Input.GetKey (KeyCode.W) && gameObject.transform.position.z < GM.transform.position.z+CloseBoundary) { //Forward movement
				GetComponent<Transform> ().Translate (Vector3.forward * spacecraft.speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.A) && gameObject.transform.position.x > GM.transform.position.x-CloseBoundary) { //Left movement
				GetComponent<Transform> ().Translate (Vector3.left * spacecraft.speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.S) && gameObject.transform.position.z > GM.transform.position.z-CloseBoundary) { //Backward movement
				GetComponent<Transform> ().Translate (Vector3.back * spacecraft.speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.D) && gameObject.transform.position.x < GM.transform.position.x+CloseBoundary) { //Right movement
				GetComponent<Transform> ().Translate (Vector3.right * spacecraft.speed * Time.deltaTime);
			}

			//Spaceship movement vertical Up/Down Arrow
			if (Input.GetKey (KeyCode.UpArrow)) { //Upward movement
				CenterPoint.GetComponent<Transform> ().Translate (Vector3.up * spacecraft.speed * Time.deltaTime);
				GetComponent<Transform> ().Translate (Vector3.up * spacecraft.speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.DownArrow)) { //Downward movement
				CenterPoint.GetComponent<Transform> ().Translate (Vector3.down * spacecraft.speed * Time.deltaTime);			
				GetComponent<Transform> ().Translate (Vector3.down * spacecraft.speed * Time.deltaTime);
			}
		}
	}

	//Rotate objects
	protected void Rotate(){
		if (targetAngle > 0){ //Rotate counter-clockwise around player
			camera.GetComponent<Transform>().RotateAround(CenterPoint.GetComponent<Transform>().position, Vector3.up, -ROTATION_AMOUNT);

			indicator.GetComponent<Transform>().RotateAround(player.GetComponent<Transform>().position, Vector3.up, -ROTATION_AMOUNT);

			turret.GetComponent<Transform>().RotateAround(turret.GetComponent<Transform>().position, Vector3.up, -ROTATION_AMOUNT);

			targetAngle -= ROTATION_AMOUNT;
		}else if(targetAngle < 0){ //Rotate clockwise around player
			camera.GetComponent<Transform>().RotateAround(CenterPoint.GetComponent<Transform>().position, Vector3.up, ROTATION_AMOUNT);

			indicator.GetComponent<Transform>().RotateAround(player.GetComponent<Transform>().position, Vector3.up, ROTATION_AMOUNT);

			turret.GetComponent<Transform>().RotateAround(turret.GetComponent<Transform>().position, Vector3.up, ROTATION_AMOUNT);

			targetAngle += ROTATION_AMOUNT;
		}
	}
}
