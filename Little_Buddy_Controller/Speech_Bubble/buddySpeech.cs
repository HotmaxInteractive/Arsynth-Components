using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buddySpeech : MonoBehaviour {

	public bool showSpeechBubble;
	public Text speechText;
	Dictionary<string, string> helloCollection;

	void Start () {
		showSpeechBubble = true;
		helloCollection = new Dictionary<string, string> ();
	
		helloCollection.Add ("Usa", "hello");
		helloCollection.Add ("Japan", "こんにちは");
		helloCollection.Add ("China", "你好");
		helloCollection.Add ("India", "नमस्ते");
		helloCollection.Add ("Canada", "sorry");
		helloCollection.Add ("Eu", "hello");
		helloCollection.Add ("England", "cheerio");
		helloCollection.Add ("Australia", "hiya mate");

	}
	
	// Update is called once per frame
	void Update () {
//		if (showSpeechBubble) {
//			gameObject.GetComponent<Canvas> ().enabled = true;
//			// get scene and use it as helloCollection key
//			speechText.text = helloCollection["Japan"];
//
//		} else {
//			gameObject.GetComponent<Canvas> ().enabled = false;
//		}
	}
}
