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
			bag.transform.parent = null;

			Debug.Log ("mass: " + bag.mass.ToString());

			Vector3 movement = new Vector3 (0f, 100.0f, 100.0f);
			//movement = movement * speed * slider.value;
			Debug.Log ("relative force: " + movement.ToString());

			bag.AddRelativeForce (movement);	
			notYetThrown = false;
		}
	}
}
