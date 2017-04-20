using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSound : MonoBehaviour, IVirtualButtonEventHandler {

	//store
	private AudioStore store;

	// TODO: REMOVE AFTER EVERYTHING IS HOOKED UP TO STORE
	//-----------------------------------------------------
	public string soundString = "holy moly";
	//-----------------------------------------------------

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

	}

	void OnTouchDown(){
		store.INCREMENT_SAMPLE ();
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		store.INCREMENT_SAMPLE ();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}
}
