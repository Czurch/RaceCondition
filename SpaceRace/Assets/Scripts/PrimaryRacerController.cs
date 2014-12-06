using UnityEngine;
using System.Collections;

public class PrimaryRacerController : MonoBehaviour {
	public GameObject spaceship;
	public GameObject bullet;
	public GameObject bulletPoint;
	public float acceleration;
	public float maxSpeed;
	private float currentSpeed;

	// Use this for initialization
	void Start () {
	
	}

	// display the players stats
	void OnGUI(){
		GUI.Label(new Rect(20,40,80,20), currentSpeed + " m/s");
	}

	// Update is called once per frame
	void FixedUpdate () {

		// set the current speed
		currentSpeed = transform.rigidbody.velocity.magnitude;

		// when the w key is pressed add force
		if (Input.GetKey (KeyCode.W) && (transform.rigidbody.velocity.magnitude != maxSpeed)) {
			transform.rigidbody.AddForce (transform.forward * acceleration);
		}

		// same for the s key but the opposite direction
		if (Input.GetKey (KeyCode.S) && (transform.rigidbody.velocity.magnitude != maxSpeed)) {
			transform.rigidbody.AddForce (transform.forward *(-1)*acceleration);
		}

		// turn the spaceship
		transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")*60*Time.deltaTime);

		// rotate the space ship
		transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.Euler(0.0f,transform.rotation.eulerAngles.y,-Input.GetAxis("Horizontal")*30), 10*Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Space)){
			shootBullet ();
		}
	}

	void shootBullet(){
		// create a bullet object
		GameObject b;
		b = (GameObject)Instantiate (bullet, bulletPoint.transform.position, transform.rotation);

		// add a force in the forward direction to the bullet
		b.rigidbody.velocity = transform.rigidbody.velocity;
		b.rigidbody.AddForce (b.transform.forward * 3000);
	}
}

	
