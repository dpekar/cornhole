using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameObject panelPrefab;
	public Canvas canvPrefab;
	public int numBags;

	// Links to other game objects
	public Slider slider;

	private Canvas canv;
	private GameObject donePanel;
	private Text scoreText;

	private int boardScore = 0;
	private int bullseyeScore = 0;

	void Awake() {
		if (instance == null) {
			instance = this;		
		} else if (instance != this) {
			Destroy (gameObject);
		}

		canv = Instantiate (canvPrefab, Vector3.zero, Quaternion.identity) as Canvas;
		scoreText = canv.transform.FindChild("ScoreText").gameObject.GetComponent<Text>();

		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (canv);
	}


	void Update() {
		if (Input.GetKeyDown ("z")) {
			Reset ();
			if (donePanel != null)
				Destroy (donePanel);
		}

		if (Input.GetKeyDown ("x")) {
			NextLevel ();
			if (donePanel != null)
				Destroy (donePanel);
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
		donePanel = Instantiate (panelPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		donePanel.transform.SetParent (canv.transform, false);
	}


	public void UpdateScore(int newScore, string scoreType) {

		if (scoreType == "BoardScoreTrigger")
			boardScore = newScore;
		else if (scoreType == "BullseyeTrigger")
			bullseyeScore = newScore;
		
		scoreText.text = "Score " + (boardScore + bullseyeScore);
	}

}


