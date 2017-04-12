using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToggleLoop : MonoBehaviour, IVirtualButtonEventHandler {

	public AudioEchoFilter delay;
	private bool looperIsOn;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		delay.decayRatio = .5f;
		looperIsOn = false;
	}

	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		looperIsOn = !looperIsOn;

		if (looperIsOn) {
			delay.decayRatio = 1;
		}else{
			delay.decayRatio = .5f;
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}
}