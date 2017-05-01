using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ClickSounds : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource audioS;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		audioS = GetComponent<AudioSource> ();
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		audioS.pitch = Random.Range(.95f, 1.05f);
		audioS.Play();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		audioS.pitch = Random.Range(.75f, .85f);
		audioS.Play();
	}

	void OnTouchDown(){
		audioS.pitch = Random.Range(.95f, 1.05f);
		audioS.Play();
	}

	void OnTouchUp(){
		audioS.pitch = Random.Range(.75f, .85f);
		audioS.Play();
	}
}
