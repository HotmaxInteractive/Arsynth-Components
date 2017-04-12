using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeKeyPress : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		// loops through keys and checks whether any were pressed
		// if pressed then initiate attack trigger - or whatever
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			if ( key.GetComponent<BasicButtonBehavior>().buttonIsPressed ) {
				StartCoroutine(doVisuals ());
			}
		}
	}

	IEnumerator doVisuals(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			if (cube != null) {
				cube.GetComponent<Animator> ().SetTrigger ("AttackTrigger");
				yield return new WaitForSeconds (0.0001f);
			}
		}
	}
}
