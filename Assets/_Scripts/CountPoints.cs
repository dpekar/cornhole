using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountPoints : MonoBehaviour {

	private List<Collider> bagsOnBoard = new List<Collider>();
	private int onBoard = 1;
	private int inHoleBonus = 1;
	private Rigidbody rb;


	void FixedUpdate () {
		int score = 0;
		foreach (Collider bag in bagsOnBoard) {
			rb = bag.GetComponent<Rigidbody> ();
			if(rb.IsSleeping()) {				
				score += onBoard;
				if (this.gameObject.name == "BullseyeTrigger") 
					score += inHoleBonus;
			}
		}	
		GameManager.instance.UpdateScore (score, this.gameObject.name);
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