using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public GameObject explosionEmitter;

	// Use this for initialization
	void Start () {
	
	}

	// destroy the bullet on collision with any object
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag != "Player"){
			Destroy (this.gameObject);

			// create an explosion
			Instantiate (explosionEmitter, transform.position, transform.rotation);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
