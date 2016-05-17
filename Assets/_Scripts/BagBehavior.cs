using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagBehavior : MonoBehaviour {

	public float speedMultiplier;
	public float rollingDrag;
	public float dragMagnitudeThreshold;

	// Debugging
	public float velocityMagnitude;
	public float reverseForceMagnitude;

	public float angle;

	private Rigidbody bag;
	private bool notYetThrown;
	private bool rolling;

	void FixedUpdate() {
		bag = GetComponent<Rigidbody> ();

		velocityMagnitude = bag.velocity.magnitude;

		if (velocityMagnitude > 1) {
			rolling = true;
		}

		if (velocityMagnitude > 15) {
			bag.isKinematic = true;
			bag.useGravity = false;
		}

		if (velocityMagnitude <= 0.1 && rolling) {
			bag.velocity =  Vector3.zero;
			bag.Sleep ();
		}

		if (velocityMagnitude < 1.5f ) {			
			Vector3 reverseForce = rollingDrag * -bag.velocity.normalized * 2;
			reverseForceMagnitude = reverseForce.magnitude;
			bag.AddForce (reverseForce);

		}
	}

	public void Grab() {
		bag = GetComponent<Rigidbody> ();
		bag.useGravity = false;
		bag.isKinematic = true;
		notYetThrown = true;
		rolling = false;
	}
		
	public void Throw() {
		bag = GetComponent<Rigidbody> ();

		if (notYetThrown) {
			Debug.Log ("Throwing");
			bag.useGravity = true;
			bag.isKinematic = false;
			bag.transform.parent = null;

			Vector3 movement = new Vector3 ( 0f, 100.0f, 100.0f);
			movement = movement * speedMultiplier * GameManager.instance.slider.value;

			bag.AddRelativeForce (movement);	
			notYetThrown = false;
		}
	}
		
}
