using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BagBehavior : MonoBehaviour {

	public float speed;
	public float angle;
	public Slider slider;

	private Rigidbody bag;
	private bool notYetThrown;


	// Use this for initialization
	void Start () {
		bag = GetComponent<Rigidbody> ();
		notYetThrown = true;
	}

	public void Grab() {
		bag.useGravity = false;
		bag.isKinematic = true;
	}
		
	public void Throw() {
		if (notYetThrown) {
			bag.useGravity = true;
			bag.isKinematic = false;

			Vector3 movement = new Vector3 (0.0f, 1.0f, -1.0f);

			bag.AddForce (movement * speed * slider.value);	
			notYetThrown = false;
			bag.transform.parent = null;

		}
	}
}
