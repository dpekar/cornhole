using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int numBags;

	// Links to other game objects
	public Text scoreText;
	public Slider slider;
	public GameObject panel; 


	void Awake() {
		if (instance == null) {
			instance = this;		
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}


	void Update() {
		if (Input.GetKeyDown ("z")) {
			Reset ();
		}

		if (Input.GetKeyDown ("x")) {
			NextLevel ();
		}

	}
		
		
	void Reset() {
		Scene currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentScene.name);
	}
		
	void NextLevel() {
		SceneManager.LoadScene ("bumpers");
	}

	public void PlayerDone() {
		
	}


	public void UpdateScore(int newScore, string scoreType) {

		int boardScore = 0;
		int holeScore = 0;

		if (scoreType == "BoardScoreTrigger")
			boardScore = newScore;
		if (scoreType == "BullseyeTrigger")
			holeScore = newScore;
		
		scoreText.text = "Score " + (boardScore + holeScore);
	}

}
