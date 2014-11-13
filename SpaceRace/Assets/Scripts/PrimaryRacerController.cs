using UnityEngine;
using System.Collections;

public class PrimaryRacerController : MonoBehaviour {
	public GameObject spaceship;
	public float speed = 20.0f;
	public float acceleration = 0.0f; 
	public int speedStat = 4;
	public int accelStat = 4;
	// Use this for initialization
	void Start () {
		Debug.Log ("PlanePilot Script has been added to " + gameObject.name);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;

		//determines acceleration based on acceleration stat
		switch(accelStat)
		{
			case 1:
				acceleration = 0.064f;
			break;
			case 2:
				acceleration = 0.067f;
			break;
			case 3:
				acceleration = 0.07f;
			break;
			case 4:
				acceleration = 0.075f;
			break;
		}

		//when "Accelerate" is pressed, the spacecraft will increase until it reaches max speed
		if (Input.GetAxis("Accelerate")> 0.001)
			{
						speed += acceleration;
			} else if (Input.GetAxis("Accelerate") == 0)			//when it is released it should return back to normal speed
				{
					if(speed > 20.0f)
					{	
						speed -= 0.5f;
					}
			}
		//determines max speed based on speed stat
		switch (speedStat) 
		{
			case 1: if(speed > 40.0f)
				speed = 40.0f;
			break;
			case 2: if(speed > 42.0f)
				speed = 42.0f;
			break;
			case 3: if(speed > 40.0f)
				speed = 44.0f;
			break;
			case 4: if(speed > 46.0f)
				speed = 46.0f;
			break;
		}

		// mouse direction
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		float shipRotate = mouseX;
		float turntime;

		if (shipRotate > 30)
		{
			shipRotate = 30;
		}
		if (shipRotate < -30)
		{
			shipRotate = -30;
		}

		// amplify the mouse movement
		float amp = -4;
		transform.Rotate (0.0f, -(amp * mouseX), 0.0f);
		spaceship.transform.Rotate (0.0f, 0.0f ,-shipRotate);


		/*
		//Launch Button
		if (Input.GetButton("Accelerate"))
		{
			speed += acceleration;
		} else if (Input.GetAxis ("Accelerate") == 0)
		*/
			
	}
}

	
