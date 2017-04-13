using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStore : MonoBehaviour {


	//start observable pattern
	public U3D.KVO.ReadOnlyValueObserving<float> echoAmount { get { return s_echoAmount; } } 
	U3D.KVO.ValueObserving<float> s_echoAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<float> chorusAmount { get { return s_chorusAmount; } } 
	U3D.KVO.ValueObserving<float> s_chorusAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<float> reverbAmount { get { return s_reverbAmount; } } 
	U3D.KVO.ValueObserving<float> s_reverbAmount = new U3D.KVO.ValueObserving<float>();

	public U3D.KVO.ReadOnlyValueObserving<bool> looper { get { return s_looper; } } 
	U3D.KVO.ValueObserving<bool> s_looper = new U3D.KVO.ValueObserving<bool>();

	public U3D.KVO.ReadOnlyValueObserving<string> sample { get { return s_sample; } } 
	U3D.KVO.ValueObserving<string> s_sample = new U3D.KVO.ValueObserving<string>();

	public U3D.KVO.ReadOnlyValueObserving<string> scale { get { return s_scale; } } 
	U3D.KVO.ValueObserving<string> s_scale = new U3D.KVO.ValueObserving<string>();


	// Initializing values
	void Start () {
		s_echoAmount.set = 0f;
		s_chorusAmount.set = 0f;
		s_reverbAmount.set = 0f;
		s_looper.set = false;

		s_sample.set = "fuzz";
		s_scale.set = "major";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
