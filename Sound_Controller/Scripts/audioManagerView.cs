using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManagerView : MonoBehaviour {

	//store
	private AudioStore store;
	private AudioEchoFilter echo;
	private AudioHighPassFilter highpass;
	private AudioReverbFilter reverb;
	private AudioChorusFilter chorus;

	private float pitchMultiplier = 1.059463094359f;
	private float volume = 0.5f;

	//make a list of audioSource Components
	public AudioSource[] keys;
	private int[] steps;

	void Awake(){
		keys = new AudioSource[7];
		RegisterKeys (7);
	}


	void Start () {

		echo = GetComponent<AudioEchoFilter> ();
		highpass = GetComponent<AudioHighPassFilter> ();
		reverb = GetComponent<AudioReverbFilter> ();
		chorus = GetComponent<AudioChorusFilter> ();

		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();

		store.scale.RegisterObserver (updatePitch);
		store.sample.RegisterObserver (updateSample);

		store.echoAmount.RegisterObserver (updateEchoAmount);
		store.highpassAmount.RegisterObserver (updateHighpassAmount);
		store.reverbAmount.RegisterObserver (updateReverbAmount);
		store.chorusAmount.RegisterObserver (updateChorusAmount);
		store.looper.RegisterObserver (updateLooper);
	}


	void RegisterKeys(int keyAmount){
		for (int i = 0; i < keyAmount; i++) {
			AudioSource source = gameObject.AddComponent<AudioSource> () as AudioSource;
			source.clip = Resources.Load ("Clips/fuzz") as AudioClip;
			source.playOnAwake = false;
			keys[i] = source;
		}
	}


	void updatePitch(string scale){

		//loop through the audiosource array and pitch them properly.

		switch (scale)  
		{  
		case "major":  
			steps = new int[] {1, 3, 5, 6, 8, 10, 12};
			break;
		case "minor":  
			steps = new int[] {1, 3, 4, 6, 8, 9, 11};
			break;  
		case "blues":  
			steps = new int[] {1, 4, 6, 7, 8, 11, 13};
			break;
		case "pentatonic":  
			steps = new int[] {1, 3, 5, 8, 10, 13, 15};
			break;
		case "whole tone":  
			steps = new int[] {1, 3, 5, 7, 9, 11, 13};
			break;
		default:
			steps = new int[] {1, 3, 5, 6, 8, 10, 12};
			break;  
		}

		for (var i = 0; i < keys.Length; i++) {
			keys[i].pitch = Mathf.Pow (pitchMultiplier, steps[i]);
		}

		Debug.Log ("Scale is updated: " + scale);
	}


	void updateSample(AudioClip sample){
		foreach (AudioSource key in keys) {
			key.clip = sample;
		}
	}
		

	void updateEchoAmount(float echoAmount){
		echo.delay = echoAmount;
		if (echo.delay >= 5000) {
			store.RESET_ECHO_AMOUNT ();
		}
	}

	void updateHighpassAmount(float highpassAmount){
		highpass.cutoffFrequency = highpassAmount;
		if (highpass.cutoffFrequency >= 6000) {
			store.RESET_HIGHPASS_AMOUNT ();
		}
	}

	void updateReverbAmount(float reverbAmount){
		reverb.decayTime = reverbAmount;
		if (reverb.decayTime >= 20) {
			store.RESET_REVERB_AMOUNT ();
		}
	}

	void updateChorusAmount(float chorusAmount){
		chorus.rate = chorusAmount;
		if (chorus.rate >= 20) {
			store.RESET_CHORUS_AMOUNT ();
		}
	}

	void updateLooper(bool looper){
		if (looper) {
			echo.decayRatio = 1f;
		} else {
			echo.decayRatio = 0.5f;
		}
	}
		
		
}
