using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChorusEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	public bool btnPress;

	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		btnPress = false;
	}


	void Update () {
		
		if (btnPress == true) {
			store.INCREMENT_CHORUS_AMOUNT();
		}

	}

	void OnTouchDown(){
		btnPress = true;
	}

	void OnTouchUp(){
		btnPress = false;
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}