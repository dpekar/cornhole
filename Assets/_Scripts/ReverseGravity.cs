using UnityEngine;
using System.Collections;

public class ReverseGravity : MonoBehaviour {

	public float gravityForce = 15f;

	void OnTriggerEnter (Collider other) {
		other.GetComponent<Rigidbody> ().useGravity = false;
	}

	void OnTriggerExit (Collider other) {
		other.GetComponent<Rigidbody> ().useGravity = true;
	}

	void OnTriggerStay(Collider other) {
		other.GetComponent<Rigidbody> ().AddForce(Vector3.left * gravityForce);
	}
}
