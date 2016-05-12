using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountPoints : MonoBehaviour {

	public GameManager gm;

	private List<Collider> bagsOnBoard = new List<Collider>();
	private int onBoard = 1;
	private int inHoleBonus = 2;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		int score = 0;
		foreach (Collider bag in bagsOnBoard) {
			score += onBoard;
			if (this.gameObject.name == "BullseyeTrigger")
				score += inHoleBonus;
		}	
		gm.UpdateScore (score, this.gameObject.name);
	}

	void OnTriggerEnter(Collider other) {
		if(!bagsOnBoard.Contains(other))
		{
			//add the object to the list
			bagsOnBoard.Add(other);
		}
	}

	void OnTriggerExit(Collider other) {
		if(bagsOnBoard.Contains(other))
		{
			//remove it from the list
			bagsOnBoard.Remove(other);
		}
	}
}