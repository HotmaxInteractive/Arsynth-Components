using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleUI : MonoBehaviour {

	Text text;
	GameObject clip;
	AudioSource source;

	void Start () {
		text = GetComponent<Text>();
		clip = GameObject.FindGameObjectWithTag ("clip");
		source = clip.GetComponent<AudioSource> ();
		text.text = source.clip.name;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = source.clip.name;

	}
}
