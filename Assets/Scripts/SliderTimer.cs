using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderTimer : MonoBehaviour {

	private Slider slider;
	//private int sliderDirection = 1;

	void Start() {
		slider = GetComponent <Slider> ();
	}

	void Update() {

		if (Input.GetKeyDown("g")) {
			slider.value += .05f;
		} else if (Input.GetKeyDown("p")) {
			slider.value -= .05f;
		}

		// slider.value += .01f * sliderDirection ; 
//		if (slider.value == slider.maxValue || slider.value == slider.minValue) {
//			sliderDirection *= -1;
//		}
	}
}
