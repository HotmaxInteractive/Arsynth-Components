using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buddyEmotions : MonoBehaviour {

	public string emotion;
	public string screenState;

	public GameObject faceScreen;
	public GameObject infoScreen;

	public Canvas speechBubble;

	public GameObject eyes;
	public GameObject mouth;	

	public Sprite baselineEyes;
	public Sprite listeningEyes;

	public Sprite baselineMouth;
	public Sprite speakingMouth;

	// Use this for initialization
	void Start () {
		makeEmotion ("neutral");

		screenState = "face";
//		faceScreen.SetActive (true);
//		infoScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.A)) {
			makeEmotion ("neutral");
		}
		if (Input.GetKeyUp(KeyCode.W)) {
			makeEmotion ("listening");
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			makeEmotion ("creating");
		}
		if (Input.GetKeyUp(KeyCode.D)) {
			makeEmotion ("speaking");
		}

		//switch screen trigger -- will be tied to the effect changes
		if (Input.GetKeyUp(KeyCode.Space)) {
			switchScreen ();
		}
	}

	public void makeEmotion (string passedEmotion) {
		emotion = passedEmotion;

		switch(emotion) {
			
		case "neutral":
			eyes.GetComponent<Image> ().sprite = baselineEyes;
			mouth.GetComponent<Image> ().sprite = baselineMouth;
			mouth.GetComponent<Animator> ().SetBool ("Speaking", false);
			speechBubble.GetComponent<buddySpeech> ().showSpeechBubble = false;
			InvokeRepeating ("blink", 0.5f, 2.5f);
			break;

		case "listening":
			eyes.GetComponent<Image> ().sprite = listeningEyes;
			mouth.GetComponent<Image> ().sprite = baselineMouth;
			mouth.GetComponent<Animator> ().SetBool ("Speaking", true);
			CancelInvoke ();
			break;

		case "creating":
			break;

		case "speaking":
			eyes.GetComponent<Image> ().sprite = baselineEyes;
			mouth.GetComponent<Image> ().sprite = speakingMouth;
			mouth.GetComponent<Animator> ().SetBool ("Speaking", true);
			speechBubble.GetComponent<buddySpeech> ().showSpeechBubble = true;
			InvokeRepeating ("blink", 0.5f, 1.5f);
			break;

		default:
			eyes.GetComponent<Image> ().sprite = baselineEyes;
			mouth.GetComponent<Image> ().sprite = baselineMouth;
			mouth.GetComponent<Animator> ().SetBool ("Speaking", false);
			break;
		}
	}

	void blink () {
		eyes.GetComponent<Animator>().SetTrigger("Blink");
	}

	void switchScreen () {
		//this isn't a bool because we might have more screenstates in the future
		//changes between face and soundInfo screen state
		if (screenState == "face") {
			screenState = "soundInfo";
			faceScreen.SetActive (false);
			infoScreen.SetActive (true);
		} else {
			screenState = "face";
			faceScreen.SetActive (true);
			infoScreen.SetActive (false);
		}


	}

}
