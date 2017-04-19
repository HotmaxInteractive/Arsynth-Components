using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeSounds : MonoBehaviour {

	public Mesh mesh;
	public GameObject prefab;
	public Transform visContainer;

	void Start () {
		
		makeVisObjs (numOfObjs: 60);
		rotatingBarsVisual ();
	}

	void Update(){
		float speed = 2;
		transform.Rotate (speed, speed, speed);
	}

	void makeVisObjs(float numOfObjs){
		for (float i = 0; i < numOfObjs; i++) {
			Object.Instantiate (prefab, visContainer);
		}
	}

	void rotatingBarsVisual(){
		foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			visualObjs.GetComponent<MeshFilter> ().mesh = mesh;
			visualObjs.transform.localPosition = new Vector3 (0, 0, 0);
			visualObjs.transform.localRotation = new Quaternion (Random.Range(1,360),Random.Range(1,360),Random.Range(1,360),1);
		}
	}
}
