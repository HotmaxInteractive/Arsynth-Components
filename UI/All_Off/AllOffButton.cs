using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOffButton : MonoBehaviour {

	public AudioEchoFilter echo;
	public AudioChorusFilter chorus;
	public AudioReverbFilter reverb;


	public void AllEffectsOff(){
		echo.decayRatio = .5f;
		echo.delay = 0;
		chorus.rate = 0;
		reverb.decayTime = 0;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
