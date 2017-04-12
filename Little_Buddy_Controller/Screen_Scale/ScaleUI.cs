using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleUI : MonoBehaviour {

	Text text;

	void Start () {
		text = GetComponent<Text>();
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			text.text = key.GetComponent<PlaySound> ().activeScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			text.text = key.GetComponent<PlaySound> ().activeScale;
		}
	}
}
