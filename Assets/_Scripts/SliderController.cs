using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

	private Slider slider;
	private float numIncrements = 50f;
	private float range;
	private float increment;

	void Start() {
		slider = GetComponent <Slider> ();
		range = slider.maxValue - slider.minValue;
		increment = range / numIncrements;
	}

	void FixedUpdate() {		

		if (Input.GetAxis("Mouse ScrollWheel") > 0.0f) {
			slider.value += increment;
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f ) {
			slider.value -= increment;
		}
	}
}
