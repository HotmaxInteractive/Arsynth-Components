using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSound : MonoBehaviour{

	//store
	private AudioStore store;

	// TODO: REMOVE AFTER EVERYTHING IS HOOKED UP TO STORE
	//-----------------------------------------------------
	public string soundString = "holy moly";
	//-----------------------------------------------------

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();

	}

	void OnTouchDown(){
		store.INCREMENT_SAMPLE ();
	}
}
