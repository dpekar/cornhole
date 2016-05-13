using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (Vector3.forward * 30);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
