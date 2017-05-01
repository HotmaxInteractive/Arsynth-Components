﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusEffectChanger : MonoBehaviour {

	public bool btnPress;

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		btnPress = false;
	}


	void Update () {

		if (btnPress == true) {
			store.INCREMENT_CHORUS_AMOUNT();
		}

	}

	void OnTouchDown(){
		btnPress = true;
	}

	void OnTouchUp(){
		btnPress = false;
	}
}