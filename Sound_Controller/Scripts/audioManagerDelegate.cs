using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerDelegate : MonoBehaviour {

	//store
	private AudioStore store;
	private AudioEchoFilter echo;
	private AudioReverbFilter reverb;
	private AudioChorusFilter chorus;


	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		store.echoAmount.RegisterObserver (updateEchoAmount);
		store.reverbAmount.RegisterObserver (updateReverbAmount);
		store.chorusAmount.RegisterObserver (updateChorusAmount);
		store.looper.RegisterObserver (updateLooper);
		echo = GetComponent<AudioEchoFilter> ();
		reverb = GetComponent<AudioReverbFilter> ();
		chorus = GetComponent<AudioChorusFilter> ();
	}

	void updateEchoAmount(float echoAmount){
		echo.delay = echoAmount;
		if (echo.delay >= 5000) {
			store.RESET_ECHO_AMOUNT ();
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
		if (echo.delay >= 20) {
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
