using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

	public float bumpIntensity = 3f;

	// Use this for initialization
	void Start () {
	
	}
	

	void OnCollisionExit (Collision info) {
		Rigidbody bag = info.rigidbody;
		bag.velocity = bag.velocity * bumpIntensity;
	}
}
