using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooperUI : MonoBehaviour {

	Text text;
	GameObject cam;
	AudioEchoFilter looper;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		cam = GameObject.FindGameObjectWithTag ("cam");
		looper = cam.GetComponent<AudioEchoFilter> ();
		if (looper.decayRatio <= .8f) {
			text.text = "Looper Off";
		} else {
			text.text = "Looper On";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (looper.decayRatio <= .8f) {
			text.text = "Looper Off";
		} else {
			text.text = "Looper On";
		}
	}
}
