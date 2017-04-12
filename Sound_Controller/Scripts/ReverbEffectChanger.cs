using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ReverbEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	public AudioReverbFilter effect;
	public bool btnPress;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		btnPress = false;

	}

	void Update () {

		if (effect.decayTime >= 20) {
			effect.decayTime = 0;
		};
		if (effect.decayTime < 2) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}

		if (btnPress == true) {
			effect.decayTime += .05f;
		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}