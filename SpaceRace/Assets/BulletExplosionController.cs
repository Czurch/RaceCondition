using UnityEngine;
using System.Collections;

public class BulletExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// destroy the emitter when its done
		Destroy (this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
