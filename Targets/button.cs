using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	AudioSource audio;
	Animator anim;

	void Start(){
		audio = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
	}

	void OnTouchDown(){
		audio.Play ();
		anim.SetTrigger ("notePress");
	}

	void OnTouchUp(){
	}

	void OnTouchStay(){
	}

	void OnTouchExit(){
	}
}
