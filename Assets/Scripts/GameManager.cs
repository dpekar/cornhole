using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] bags;
	public GameObject cameraObj;
	public Text scoreText;

	private bool bagInHand = false;
	private int onBag = 0;
	private GameObject currentBag;
	private Vector3[] bagPositions;

	private int boardScore = 0;
	private int holeScore = 0;

	void Start () {
		Invoke ("GrabNextBag", 0.5f);
		bagPositions = new Vector3 [4];
		storeBagPositions ();

	}


	void GrabNextBag() {
		if (onBag < 4) {
			currentBag = bags [onBag];
			BagBehavior bb = currentBag.GetComponent<BagBehavior> ();
			bb.Grab ();
			currentBag.transform.parent = null;
			currentBag.transform.SetParent (cameraObj.transform);

			bagInHand = true;
		}
	}

	void Update() {
		if (Input.GetKeyDown ("r")) {
			Reset ();
		}
	}

	void FixedUpdate () {

		PositionBag ();

		ThrowBag ();

		PickupBagIfReady();
	}

	void storeBagPositions() {
		for(int i = 0; i < bags.Length; i++) {
			bagPositions[i] = bags[i].transform.position;
		}
	}

	void Reset() {
		Scene currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentScene.name);
	}

	void PositionBag() {
			
		// Position of bag in hang in front of you 
		if(currentBag != null && bagInHand) {
			currentBag.transform.parent = cameraObj.transform;

//			currentBag.transform.position = cameraObj.transform.position;
//			currentBag.transform.position += new Vector3(0.0f, -0.5f, -1.0f);
//			currentBag.transform.rotation = Quaternion.Euler(10, 0, 0);
		}
	}

	void ThrowBag() {
		if (Input.GetButton("Fire1") && bagInHand) {
			bagInHand = false;

			BagBehavior bb = currentBag.GetComponent<BagBehavior> ();
			bb.Throw ();
			onBag++;
		}
	}

	void PickupBagIfReady() {
		bool readyForNextBag = Input.GetButton ("Fire2") && !bagInHand && currentBag.GetComponent<Rigidbody> ().IsSleeping ();

		if (readyForNextBag) {
			GrabNextBag ();
		}
	}





	public void UpdateScore(int newScore, string scoreType) {
		if (scoreType == "BoardScoreTrigger")
			boardScore = newScore;
		if (scoreType == "BullseyeTrigger")
			holeScore = newScore;
		
		scoreText.text = "Score " + (boardScore + holeScore);
	}

}
