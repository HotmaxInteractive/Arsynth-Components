using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenSwitcher : MonoBehaviour {

	//start public Vars
	public AudioEchoFilter echo;
	public AudioChorusFilter chorus;
	public AudioReverbFilter reverb;

	public ChangeSound sample;
	public PlaySound scale;

	float echoChange;
	float reverbChange;
	float chorusChange;

	string sampleChange;
	string scaleChange;

//	public GameObject echoScreen;
//	public GameObject chorusScreen;
//	public GameObject reverbScreen;
//	public GameObject scaleScreen;
//	public GameObject sampleScreen;
//	public GameObject faceScreen;

	public Canvas echoScreen;
	public Canvas chorusScreen;
	public Canvas reverbScreen;
	public Canvas scaleScreen;
	public Canvas sampleScreen;
	public Canvas faceScreen;

	void start(){

		echoChange = echo.delay;
		reverbChange = reverb.decayTime;
		chorusChange = chorus.rate;   

		sampleChange = sample.soundString;
		scaleChange = scale.activeScale;
	}


//	void stringChangeWatcher(string current, string changeMemory) {
//		if (changeMemory != current) {
//
//			Debug.Log(changeMemory + " " + current);
//
//
//			changeMemory = current;
//			// move script
//
//			Debug.Log(changeMemory + " " + current);
//		}
//	}

	void Update () {

//		floatChangeWatcher (current: echo.delay, changeMemory: echoChange);
//		floatChangeWatcher (current: reverb.decayTime, changeMemory: reverbChange);
//		floatChangeWatcher (current: chorus.rate, changeMemory: chorusChange);
//
//		stringChangeWatcher (current: sample.soundString, changeMemory: sampleChange);

		echoChangeWatcher ();
		chorusChangeWatcher ();
		reverbChangeWatcher ();
		scaleChangeWatcher ();
		sampleChangeWatcher ();

	}

//	void floatChangeWatcher(float currentFloat, float changeMemoryFloat) {
//		
//		if (changeMemoryFloat != currentFloat) {
//			changeMemoryFloat = currentFloat;
//
//			// move script
//			Debug.Log(" float change");
//		}
//	}

	void echoChangeWatcher() {
		if (echoChange != echo.delay) {
			echoChange = echo.delay;

			// move script

			CancelInvoke ("faceScreenChange");

			echoScreen.enabled = true;
			chorusScreen.enabled = false;
			reverbScreen.enabled = false;
			sampleScreen.enabled = false;
			scaleScreen.enabled = false;
			faceScreen.enabled = false;

			Invoke ("faceScreenChange", 2);
		}
	}

	void chorusChangeWatcher() {
		if (chorusChange != chorus.rate) {
			chorusChange = chorus.rate;

			// move script

			CancelInvoke ("faceScreenChange");

			echoScreen.enabled = false;
			chorusScreen.enabled = true;
			reverbScreen.enabled = false;
			sampleScreen.enabled = false;
			scaleScreen.enabled = false;
			faceScreen.enabled = false;

			Invoke ("faceScreenChange", 2);
		}
	}

	void reverbChangeWatcher() {
		if (reverbChange != reverb.decayTime) {
			reverbChange = reverb.decayTime;

			// move script

			CancelInvoke ("faceScreenChange");

			echoScreen.enabled = false;
			chorusScreen.enabled = false;
			reverbScreen.enabled = true;
			sampleScreen.enabled = false;
			scaleScreen.enabled = false;
			faceScreen.enabled = false;

			Invoke ("faceScreenChange", 2);
		}
	}
		
	void scaleChangeWatcher() {
		if (scaleChange != scale.activeScale) {
			scaleChange = scale.activeScale;

			// move script
			CancelInvoke ("faceScreenChange");

			echoScreen.enabled = false;
			chorusScreen.enabled = false;
			reverbScreen.enabled = false;
			sampleScreen.enabled = false;
			scaleScreen.enabled = true;
			faceScreen.enabled = false;

			Invoke ("faceScreenChange", 2);
		}
	}

	void sampleChangeWatcher() {
		if (sampleChange != sample.soundString) {
			sampleChange = sample.soundString;

			// move script
			CancelInvoke ("faceScreenChange");

			echoScreen.enabled = false;
			chorusScreen.enabled = false;
			reverbScreen.enabled = false;
			sampleScreen.enabled = true;
			scaleScreen.enabled = false;
			faceScreen.enabled = false;

			Invoke ("faceScreenChange", 2);
		}
	}

	void faceScreenChange(){
		echoScreen.enabled = false;
		chorusScreen.enabled = false;
		reverbScreen.enabled = false;
		sampleScreen.enabled = false;
		scaleScreen.enabled = false;
		faceScreen.enabled = true;
	}
}
