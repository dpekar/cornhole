using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject ball;

	// Game State Holders
	private bool bagInHand = false;
	private Camera cam;
	private int onBag = 0;
	private GameObject currentBag;


	void Start () {
		cam = GetComponent<Camera> ();
		GrabNextBag ();
	}

	void GrabNextBag() {
		if (onBag < GameManager.instance.numBags) {
			currentBag = Instantiate (ball, Vector3.zero, Quaternion.identity) as GameObject;
			currentBag.GetComponent<BagBehavior> ().Grab ();
			currentBag.transform.parent = null;
			currentBag.transform.SetParent (cam.transform);

			bagInHand = true;
		} else {
			GameManager.instance.PlayerDone();
		}

	}

	void FixedUpdate () {

		PositionBag ();

		ThrowBag ();

		PickupBagIfReady();
	}

	void PositionBag() {			
		// Position of bag in hang in front of you 
		if(currentBag != null && bagInHand) {
			currentBag.transform.position = cam.transform.position;
			currentBag.transform.rotation = cam.transform.rotation;
			currentBag.transform.Translate (new Vector3 (0f, -0.2f, 0.7f));
			currentBag.transform.parent = cam.transform;
		}
	}

	void ThrowBag() {
		if (Input.GetButton("Fire1") && bagInHand) {
			bagInHand = false;		
			currentBag.transform.parent = null;

			currentBag.GetComponent<BagBehavior> ().Throw();
			onBag++;
		}

	}

	void PickupBagIfReady() {
		bool readyForNextBag = !bagInHand && currentBag.GetComponent<Rigidbody> ().IsSleeping ();

		if (readyForNextBag) {
			GrabNextBag ();
		}
	}
}