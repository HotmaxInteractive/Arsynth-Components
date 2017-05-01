using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToggleLoop : MonoBehaviour, IVirtualButtonEventHandler {

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		store.TOGGLE_LOOPER ();

		/*if (looperIsOn) {
			delay.decayRatio = 1;
		}else{
			delay.decayRatio = .5f;
		}*/
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}

	void OnTouchDown(){
		store.TOGGLE_LOOPER ();
	}
}