using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenView : MonoBehaviour {

	private AudioStore store;
	private List<GameObject> effectCollection = new List<GameObject>();
	private GameObject faceCanvas;

	void Awake(){
		faceCanvas = gameObject.transform.parent.Find ("FaceScreen").gameObject;
		effectCollection.Add(gameObject.transform.parent.Find ("ScaleScreen").gameObject);
	}

	void Start () {
		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();

		store.scale.RegisterObserver (updateScale);
		store.echoAmount.RegisterObserver (updateEcho);
		store.reverbAmount.RegisterObserver (updateReverb);
		store.chorusAmount.RegisterObserver (updateChorus);
	}

	//watchers -- passes string that sets component
	// THESE NEED TO BE THE SAME STRING AS IN THE EDITOR
	private void updateScale(string whatev){
		showEffects ("ScaleScreen");
	}
	private void updateEcho(float whatev){
		showEffects ("EchoScreen");
	}
	private void updateReverb(float whatev){
		showEffects ("ReverbScreen");
	}
	private void updateChorus(float whatev){
		showEffects ("ChorusScreen");
	}


	// Every canvas is off except canvas passed in -- and then face is turned back on eventually
	private void showEffects(string type) {
		
		faceCanvas.GetComponent<Canvas> ().enabled = false;
		foreach(GameObject effectScreen in effectCollection){
			if (effectScreen.name == type) {
				effectScreen.GetComponent<Canvas> ().enabled = true;
			} else {
				effectScreen.GetComponent<Canvas> ().enabled = false;
			}
		}

		Invoke("timeoutToFace", 5);
	}


	//turn face back on eventually, turn effects off again
	private void timeoutToFace(){

		faceCanvas.GetComponent<Canvas> ().enabled = true;
		foreach(GameObject effectScreen in effectCollection){
			effectScreen.GetComponent<Canvas> ().enabled = false;
		}
	}


}
