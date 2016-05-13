using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	public float bumpIntensity = 5f;

	// Use this for initialization
	void Start () {
	
	}
	

	void OnCollisionExit (Collision info) {
		Rigidbody bag = info.rigidbody;
		Debug.Log ("Hit a bumper");
		bag.velocity = bag.velocity * bumpIntensity;
	}
}
