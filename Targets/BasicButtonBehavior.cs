using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class BasicButtonBehavior : MonoBehaviour, IVirtualButtonEventHandler {
	public Boolean buttonIsPressed;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		buttonIsPressed = true;
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
		buttonIsPressed = false;
	}

	void Update () {
		
	}
}
