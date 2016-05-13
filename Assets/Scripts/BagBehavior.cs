using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagBehavior : MonoBehaviour {

	public float speed;
	public float rollingDrag;
	public float dragMagnitudeThreshold;

	// Debugging
	public float velocityMagnitude;
	public float reverseForceMagnitude;


	public float angle;
	public Slider slider;

	private Rigidbody bag;
	private bool notYetThrown;


	// Use this for initialization
	void Start () {
		bag = GetComponent<Rigidbody> ();
		notYetThrown = true;
	}

	void FixedUpdate() {
		velocityMagnitude = bag.velocity.magnitude;

		if (velocityMagnitude > 15) {
			bag.isKinematic = true;
			bag.useGravity = false;
		}

		if (velocityMagnitude <= 0.05) {
			bag.velocity =  Vector3.zero;
			bag.Sleep ();
		}


		if (velocityMagnitude > 0.5/*dragMagnitudeThresholdLow*/ && velocityMagnitude < 1/*dragMagnitudeThresholdHigh*/) {			
			Vector3 reverseForce = rollingDrag * -bag.velocity.normalized * 2;
			reverseForceMagnitude = reverseForce.magnitude;
			bag.AddForce (reverseForce);
		}
	}

	public void Grab() {
		bag.useGravity = false;
		bag.isKinematic = true;
	}
		
	public void Throw() {
		if (notYetThrown) {
			bag.useGravity = true;
			bag.isKinematic = false;
			bag.transform.parent = null;

			Vector3 movement = new Vector3 ( 0f, 100.0f, 100.0f);
			movement = movement * speed * slider.value;

			bag.AddRelativeForce (movement);	
			notYetThrown = false;
		}
	}
		
}
