using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EchoEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	public bool btnPress;

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		btnPress = false;
	}

	void Update () {
/*		if (effect.delay >= 5000) {
			effect.delay = 0;
		};
		if (effect.delay < 500) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}
			*/
		if (btnPress == true) {
			store.INCREMENT_ECHO_AMOUNT();
		}
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}