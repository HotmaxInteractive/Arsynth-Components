using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaySound : MonoBehaviour, IVirtualButtonEventHandler {

	//TODO: move steps and multiplier to audioManager
	[SerializeField]
	private float majorSteps, minorSteps, bluesSteps, pentatonicSteps, wholeToneSteps;

	// TODO: DELETE THIS AFTER EVERYTHING HAS BEEN FIXED
	// -------------------------------------------
	public string activeScale = "holymoly";
	//---------------------------------------------


	public int keyNumber;


	//store
	private AudioStore store;
	private audioManagerView audioManager;

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		audioManager = GameObject.FindGameObjectWithTag ("Sound_Board").GetComponent<audioManagerView>();

		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}


	// Vuforia Button Events

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){

		//GRAB THE AUDIOMANAGER BY TAG -- and use the public keyNumber to turn on the audioSource in the public array.
		audioManager.keys [keyNumber].Play ();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){

	}

	// Touch Input Events

	void OnTouchDown(){
		audioManager.keys [keyNumber].Play ();
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
	}

	void OnTouchUp(){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
	}

}
