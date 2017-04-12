using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSound : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource[] sources;
	GameObject sounds;
	AudioClip soundName;
	int iterator;
	AudioClip[] clips = new AudioClip[6];
	public string soundString;

	void Start () {
		sounds = GameObject.Find ("Sounds");
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		sources = sounds.GetComponentsInChildren<AudioSource> ();
		iterator = 0;

		//TODO take out demung, toy piano, rhodes, organ, 

		clips[0] = Resources.Load ("Clips/fuzz") as AudioClip;
		clips[1] = Resources.Load ("Clips/glass pad") as AudioClip;
		clips[2] = Resources.Load ("Clips/arpeggio") as AudioClip;
		clips[3] = Resources.Load ("Clips/triangle") as AudioClip;
		clips[4] = Resources.Load ("Clips/viola") as AudioClip;
		clips[5] = Resources.Load ("Clips/derp") as AudioClip;


	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		
		iterator++;
		if (iterator == clips.Length){ iterator = 0; }

		foreach (AudioSource source in sources) {
			source.clip = clips[iterator];
		}

		soundString = clips [iterator].name;
	}
		
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

	void Update () {}
}
