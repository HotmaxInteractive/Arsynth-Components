using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleView : MonoBehaviour {

	private AudioStore store;
	private Text scaleTracker;

	// Use this for initialization
	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		store.scale.RegisterObserver (updateScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateScale(string scale){
		scaleTracker = transform.parent.FindChild ("Scale").GetComponent<Text>();
		scaleTracker.text = scale;
	}
}
