using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStore : MonoBehaviour {

	//private sampleCollection/scaleCollection and hookable active values
	private List<sampleItem> __sampleCollection = new List<sampleItem>();
	public U3D.KVO.ReadOnlyValueObserving<AudioClip> sample { get { return __sample; } } 
	U3D.KVO.ValueObserving<AudioClip> __sample = new U3D.KVO.ValueObserving<AudioClip>();
	U3D.KVO.ValueObserving<int> __samplePosition = new U3D.KVO.ValueObserving<int>();

	private List<string> __scaleCollection = new List<string>();
	public U3D.KVO.ReadOnlyValueObserving<string> scale { get { return __scale; } } 
	U3D.KVO.ValueObserving<string> __scale = new U3D.KVO.ValueObserving<string>();
	U3D.KVO.ValueObserving<int> __scalePosition = new U3D.KVO.ValueObserving<int>();


	//other observables
	public U3D.KVO.ReadOnlyValueObserving<float> echoAmount { get { return __echoAmount; } } 
	U3D.KVO.ValueObserving<float> __echoAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<float> chorusAmount { get { return __chorusAmount; } } 
	U3D.KVO.ValueObserving<float> __chorusAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<float> reverbAmount { get { return __reverbAmount; } } 
	U3D.KVO.ValueObserving<float> __reverbAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<bool> looper { get { return __looper; } } 
	U3D.KVO.ValueObserving<bool> __looper = new U3D.KVO.ValueObserving<bool>();


	// Initializing values
	void Start () {

		__sampleCollection.Add (new sampleItem("fuzz"));
		__sampleCollection.Add (new sampleItem("glass pad"));
		__sampleCollection.Add (new sampleItem("arpeggio"));
		__sampleCollection.Add (new sampleItem("triangle"));
		__sampleCollection.Add (new sampleItem("viola"));
		__sampleCollection.Add (new sampleItem("derp"));
		__samplePosition.set = 0;
		__sample.set = __sampleCollection [__samplePosition.get].clip;


		__scaleCollection.Add ("major");
		__scaleCollection.Add ("minor");
		__scaleCollection.Add ("blues");
		__scaleCollection.Add ("pentatonic");
		__scaleCollection.Add ("wholetone");
		__scalePosition.set = 0;
		__scale.set = __scaleCollection [__scalePosition.get];


		__echoAmount.set = 0f;
		__chorusAmount.set = 0f;
		__reverbAmount.set = 0f;
		__looper.set = false;

	}


	// -----------------------------------------
	//           M U T A T O R S
	//------------------------------------------
	public void INCREMENT_ECHO_AMOUNT (){
		__echoAmount.set = __echoAmount.get + 15f;
	}
	public void INCREMENT_REVERB_AMOUNT (){
		__reverbAmount.set = __reverbAmount.get + 0.5f;
	}
	public void INCREMENT_CHORUS_AMOUNT (){
		__chorusAmount.set = __chorusAmount.get + 0.5f;
	}
	public void RESET_ECHO_AMOUNT (){
		__echoAmount.set = 0f;
	}
	public void RESET_REVERB_AMOUNT (){
		__reverbAmount.set = 0f;
	}
	public void RESET_CHORUS_AMOUNT (){
		__chorusAmount.set = 0f;
	}

	public void TOGGLE_LOOPER(){
		__looper.set = !__looper.get;
	}

	public void INCREMENT_SCALE (){
		if (__scalePosition.get >= __scaleCollection.Count) {
			__scalePosition.set = 0;
		} else {
			__scalePosition.set = __scalePosition.get + 1;
		}
		__scale.set = __scaleCollection [__scalePosition.get];
	}
	public void INCREMENT_SAMPLE (){
		if (__samplePosition.get >= __sampleCollection.Count) {
			__samplePosition.set = 0;
		} else {
			__samplePosition.set = __samplePosition.get + 1;
		}
		__sample.set = __sampleCollection [__samplePosition.get].clip;
	}


	//wrapper for item in sampleCollection
	public class sampleItem {
		public string name;
		public AudioClip clip;
		public sampleItem(string sampleName) {
			name = sampleName;
			clip = Resources.Load("Clips/" + sampleName) as AudioClip;
		}
	}
		
}
