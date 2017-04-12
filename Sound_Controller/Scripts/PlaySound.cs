using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaySound : MonoBehaviour, IVirtualButtonEventHandler {
	AudioSource source;
	public GameObject soundSource;
	public string activeScale;
	public float majorSteps;
	public float minorSteps;
	public float bluesSteps;
	public float pentatonicSteps;
	public float wholeToneSteps;
	public float pitchMultiplier;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		source = soundSource.GetComponent<AudioSource> ();
		source.clip = Resources.Load ("Clips/fuzz") as AudioClip;
		source.volume = .5f;
		pitchMultiplier = 1.059463094359f;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		source.Play ();
		source.loop = true;
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		source.loop = false;
	}

	void Update(){

		switch (activeScale)  
		{  
		case "major":  
			source.pitch = Mathf.Pow (pitchMultiplier, majorSteps);
			break;
		case "minor":  
			source.pitch = Mathf.Pow (pitchMultiplier, minorSteps);  
			break;  
		case "blues":  
			source.pitch = Mathf.Pow (pitchMultiplier, bluesSteps); 
			break;
		case "pentatonic":  
			source.pitch = Mathf.Pow (pitchMultiplier, pentatonicSteps);  
			break;
		case "whole tone":  
			source.pitch = Mathf.Pow (pitchMultiplier, wholeToneSteps);  
			break;
		default:  
			source.pitch = Mathf.Pow (pitchMultiplier, majorSteps);  
			break;  
		}  

	}
}
