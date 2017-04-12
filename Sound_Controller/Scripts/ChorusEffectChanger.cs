using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChorusEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	public AudioChorusFilter effect;
	public bool btnPress;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		btnPress = false;
	}

	void Update () {
		
		if (effect.rate >= 20) {
			effect.rate = 0;
		};
		if (effect.rate < 2) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}

		if (btnPress == true) {
			effect.rate += .05f;

		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}