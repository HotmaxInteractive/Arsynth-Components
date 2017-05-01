﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour{

	// TODO: DELETE THIS AFTER EVERYTHING HAS BEEN FIXED
	// -------------------------------------------
	public string activeScale = "holymoly";
	//---------------------------------------------


	public int keyNumber;


	//store
	private AudioStore store;
	private audioManagerView audioManager;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		audioManager = GameObject.FindGameObjectWithTag ("Sound_Board").GetComponent<audioManagerView>();
	}

	// Touch Input Events

	void OnTouchDown(){
		audioManager.keys [keyNumber].Play ();
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
	}

	void OnTouchUp(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
	}

	void OnTouchExit(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
	}

}
