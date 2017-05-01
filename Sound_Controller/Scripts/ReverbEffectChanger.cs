using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbEffectChanger : MonoBehaviour {

	public bool btnPress;

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		btnPress = false;
	}

	void Update () {

		if (btnPress == true) {
			store.INCREMENT_REVERB_AMOUNT();
		}
	}

	void OnTouchDown(){
		btnPress = true;
	}

	void OnTouchUp(){
		btnPress = false;
	}
}