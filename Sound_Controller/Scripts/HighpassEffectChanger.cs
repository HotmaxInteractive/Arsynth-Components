using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighpassEffectChanger : MonoBehaviour {


	public bool btnPress;

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		btnPress = false;
	}

	void Update () {

		if (btnPress == true) {
			//			store.INCREMENT_ECHO_AMOUNT();
			store.INCREMENT_HIGHPASS_AMOUNT();
		}
	}

	void OnTouchDown(){
		btnPress = true;
	}

	void OnTouchUp(){
		btnPress = false;
	}
}
