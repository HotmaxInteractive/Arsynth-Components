using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaySound : MonoBehaviour, IVirtualButtonEventHandler {

	//note being played
	AudioSource note;

	//steps and multiplier
	[SerializeField]
	private float majorSteps, minorSteps, bluesSteps, pentatonicSteps, wholeToneSteps;
	private float pitchMultiplier = 1.059463094359f;
	private float volume = 0.5f;


	// DELETE THIS AFTER EVERYTHING HAS BEEN FIXED
	// -------------------------------------------
	public string activeScale = "holymoly";
	//---------------------------------------------


	//store
	private AudioStore store;


	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		store.scale.RegisterObserver (updatePitch);
		store.sample.RegisterObserver (updateSample);

		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		note.volume = volume;
		note.Play ();

	}
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}
		

	void updatePitch(string scale){
		switch (scale)  
		{  
		case "major":  
			note.pitch = Mathf.Pow (pitchMultiplier, majorSteps);
			break;
		case "minor":  
			note.pitch = Mathf.Pow (pitchMultiplier, minorSteps);  
			break;  
		case "blues":  
			note.pitch = Mathf.Pow (pitchMultiplier, bluesSteps); 
			break;
		case "pentatonic":  
			note.pitch = Mathf.Pow (pitchMultiplier, pentatonicSteps);  
			break;
		case "whole tone":  
			note.pitch = Mathf.Pow (pitchMultiplier, wholeToneSteps);  
			break;
		default:  
			note.pitch = Mathf.Pow (pitchMultiplier, majorSteps);  
			break;  
		}  
	}

	void updateSample(AudioClip sample){
		note.clip = sample;
	}
}
