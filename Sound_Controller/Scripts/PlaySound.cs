using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

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

	void OnTouchDown(){

		//GRAB THE AUDIOMANAGER BY TAG -- and use the public keyNumber to turn on the audioSource in the public array.
		audioManager.keys [keyNumber].Play ();

	}
}
