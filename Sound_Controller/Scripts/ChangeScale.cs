using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeScale : MonoBehaviour, IVirtualButtonEventHandler {
	
	//store
	private AudioStore store;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

	}

	void OnTouchDown(){
		store.INCREMENT_SCALE ();
	}


	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		store.INCREMENT_SCALE ();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

}

