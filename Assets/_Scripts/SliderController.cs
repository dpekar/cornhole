using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

	public float increment;

	private Slider slider;
	private float range;

	void Start() {
		slider = GetComponent <Slider> ();
		range = slider.maxValue - slider.minValue;
	}

	void Update() {

		if (Input.GetKeyDown("g")) {
			
			slider.value += range * increment;
		} else if (Input.GetKeyDown("p")) {
			slider.value -= range * increment;
		}
	}
}
