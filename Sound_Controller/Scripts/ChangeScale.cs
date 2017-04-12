using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeScale : MonoBehaviour, IVirtualButtonEventHandler {
	
	PlaySound[] playsound;
	int i;
	string[] scaleTypes = new string[5];

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		scaleTypes[0] = "major";
		scaleTypes[1] = "minor";
		scaleTypes[2] = "blues";
		scaleTypes[3] = "pentatonic";
		scaleTypes[4] = "whole tone";

		// set activeScale on every button
		foreach (GameObject btn in GameObject.FindGameObjectsWithTag("key")) {
			btn.GetComponent<PlaySound>().activeScale = scaleTypes[0];
		}
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		i++;

		if (i == scaleTypes.Length){ i = 0; }
		foreach (GameObject btn in GameObject.FindGameObjectsWithTag("key")) {
			btn.GetComponent<PlaySound>().activeScale = scaleTypes[i];
		}
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

	void Update () {
	}
}

