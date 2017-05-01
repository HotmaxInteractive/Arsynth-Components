using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasicButtonBehavior : MonoBehaviour {
	public Boolean buttonIsPressed;

	void Start () {
	}

	void OnTouchDown(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		buttonIsPressed = true;
	}

	void OnTouchUp(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
		buttonIsPressed = false;
	}

	void OnTouchExit(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
		buttonIsPressed = false;
	}
}
