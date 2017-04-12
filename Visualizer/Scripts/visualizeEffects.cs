using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeEffects : MonoBehaviour {

	public AudioReverbFilter reverb;
	public AudioEchoFilter echo;
	public AudioChorusFilter chorus;

	void Start () {

	}

	void Update () {

		// add reverb effect to visualizer
		float decay = reverb.decayTime;
		float delay = echo.delay;
		float rate = chorus.rate;

//		gameObject.transform.localPosition = new Vector3(delay, decay, rate);
	}
}
