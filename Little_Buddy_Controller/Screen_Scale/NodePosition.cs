using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NodePosition : MonoBehaviour {

	private AudioStore store;
	private string scale;

	string previousScale;

	public Transform node0;
	public Transform node1;
	public Transform node2;
	public Transform node3;
	public Transform node4;
	public Transform node5;
	public Transform node6;
	public Transform node7;
	public Transform node8;
	public Transform node9;
	public Transform node10;
	public Transform node11;

	private List<Transform> nodesCollection = new List<Transform>();
	Vector3 [] homePositions = new Vector3[12];

	bool active;

	Color c1 = Color.red;
	Color c2 = Color.red;

	//memory of last active Position
	Vector3 lastActivePosition;



	void Start () {

		store = GameObject.FindGameObjectWithTag ("Store_Audio").GetComponent<AudioStore>();
		store.scale.RegisterObserver (updateScale);

		//setting nodes - could change
		nodesCollection.Add(node0);
		nodesCollection.Add(node1);
		nodesCollection.Add(node2);
		nodesCollection.Add(node3);
		nodesCollection.Add(node4);
		nodesCollection.Add(node5);
		nodesCollection.Add(node6);
		nodesCollection.Add(node7);
		nodesCollection.Add(node8);
		nodesCollection.Add(node9);
		nodesCollection.Add(node10);
		nodesCollection.Add(node11);


		//style lines AND SET HOME POSITION
		for (int i = 0; i < nodesCollection.Count; i++) {
			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().startWidth = 6f;
			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().endWidth = 6f;

			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().material = new Material (Shader.Find ("Standard"));
			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().material.color = new Color(245, 0, 0, 255);

			homePositions [i] = nodesCollection [i].transform.localPosition;
		}

		//draw initial lines
		drawLines ();
		scaleSetter ();
	}


	private void updateScale(string newScale) {
		scale = newScale;
	}


	void MoveNode(){
		
		if(previousScale != scale){
			previousScale = scale;
			for (int i = 0; i < nodesCollection.Count; i++) {

				if (scale == "major") {
					if (i == 0) {active = true;}
					if (i == 1) {active = false;}
					if (i == 2) {active = true;}
					if (i == 3) {active = false;}
					if (i == 4) {active = true;}
					if (i == 5) {active = true;}
					if (i == 6) {active = false;}
					if (i == 7) {active = true;}
					if (i == 8) {active = false;}
					if (i == 9) {active = true;}
					if (i == 10) {active = false;}
					if (i == 11) {active = true;}
				}

				if (scale == "pentatonic") {
					if (i == 0) {active = true;}
					if (i == 1) {active = false;}
					if (i == 2) {active = true;}
					if (i == 3) {active = false;}
					if (i == 4) {active = true;}
					if (i == 5) {active = false;}
					if (i == 6) {active = false;}
					if (i == 7) {active = true;}
					if (i == 8) {active = false;}
					if (i == 9) {active = true;}
					if (i == 10) {active = false;}
					if (i == 11) {active = false;}
				}

				if (scale == "whole tone") {
					if (i == 0) {active = true;}
					if (i == 1) {active = false;}
					if (i == 2) {active = true;}
					if (i == 3) {active = false;}
					if (i == 4) {active = true;}
					if (i == 5) {active = false;}
					if (i == 6) {active = true;}
					if (i == 7) {active = false;}
					if (i == 8) {active = true;}
					if (i == 9) {active = false;}
					if (i == 10) {active = true;}
					if (i == 11) {active = false;}
				}

				if (scale == "minor") {
					if (i == 0) {active = true;}
					if (i == 1) {active = false;}
					if (i == 2) {active = true;}
					if (i == 3) {active = true;}
					if (i == 4) {active = false;}
					if (i == 5) {active = true;}
					if (i == 6) {active = false;}
					if (i == 7) {active = true;}
					if (i == 8) {active = true;}
					if (i == 9) {active = false;}
					if (i == 10) {active = true;}
					if (i == 11) {active = false;}
				}

				if (scale == "blues") {
					if (i == 0) {active = true;}
					if (i == 1) {active = false;}
					if (i == 2) {active = false;}
					if (i == 3) {active = true;}
					if (i == 4) {active = false;}
					if (i == 5) {active = true;}
					if (i == 6) {active = true;}
					if (i == 7) {active = true;}
					if (i == 8) {active = false;}
					if (i == 9) {active = false;}
					if (i == 10) {active = true;}
					if (i == 11) {active = false;}
				}

				if (active == true) {
					nodesCollection [i].transform.localPosition = homePositions [i];
					lastActivePosition = nodesCollection [i].transform.position;
				}

				//updates last active position to latest inactive node
				if (active == false) {
					nodesCollection [i].transform.DOMove (lastActivePosition, 1);

				}
			}
		}
		//draw lines after setting
		drawLines ();

	}




	void drawLines () {
		for (int i = 0; i < homePositions.Length; i++) {
			int nextPosition;
			if (i == homePositions.Length - 1) {
				nextPosition = 0;	
			} else {
				nextPosition = i + 1;
			}

			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().SetPosition (0, nodesCollection [i].position);
			nodesCollection [i].gameObject.GetComponent<LineRenderer> ().SetPosition (1, nodesCollection [nextPosition].position);
		}
	}

	void scaleSetter(){

		for (int i = 0; i < nodesCollection.Count; i++) {

			if (scale == "major") {
				if (i == 0) {active = true;}
				if (i == 1) {active = false;}
				if (i == 2) {active = true;}
				if (i == 3) {active = false;}
				if (i == 4) {active = true;}
				if (i == 5) {active = true;}
				if (i == 6) {active = false;}
				if (i == 7) {active = true;}
				if (i == 8) {active = false;}
				if (i == 9) {active = true;}
				if (i == 10) {active = false;}
				if (i == 11) {active = true;}
			}

			if (scale == "pentatonic") {
				if (i == 0) {active = true;}
				if (i == 1) {active = false;}
				if (i == 2) {active = true;}
				if (i == 3) {active = false;}
				if (i == 4) {active = true;}
				if (i == 5) {active = false;}
				if (i == 6) {active = false;}
				if (i == 7) {active = true;}
				if (i == 8) {active = false;}
				if (i == 9) {active = true;}
				if (i == 10) {active = false;}
				if (i == 11) {active = false;}
			}

			if (scale == "whole tone") {
				if (i == 0) {active = true;}
				if (i == 1) {active = false;}
				if (i == 2) {active = true;}
				if (i == 3) {active = false;}
				if (i == 4) {active = true;}
				if (i == 5) {active = false;}
				if (i == 6) {active = true;}
				if (i == 7) {active = false;}
				if (i == 8) {active = true;}
				if (i == 9) {active = false;}
				if (i == 10) {active = true;}
				if (i == 11) {active = false;}
			}

			if (scale == "minor") {
				if (i == 0) {active = true;}
				if (i == 1) {active = false;}
				if (i == 2) {active = true;}
				if (i == 3) {active = true;}
				if (i == 4) {active = false;}
				if (i == 5) {active = true;}
				if (i == 6) {active = false;}
				if (i == 7) {active = true;}
				if (i == 8) {active = true;}
				if (i == 9) {active = false;}
				if (i == 10) {active = true;}
				if (i == 11) {active = false;}
			}

			if (scale == "blues") {
				if (i == 0) {active = true;}
				if (i == 1) {active = false;}
				if (i == 2) {active = false;}
				if (i == 3) {active = true;}
				if (i == 4) {active = false;}
				if (i == 5) {active = true;}
				if (i == 6) {active = true;}
				if (i == 7) {active = true;}
				if (i == 8) {active = false;}
				if (i == 9) {active = false;}
				if (i == 10) {active = true;}
				if (i == 11) {active = false;}
			}


			if (active == true) {
				nodesCollection [i].transform.position = homePositions [i];
				lastActivePosition = nodesCollection [i].transform.position;
			}

			//updates last active position to latest inactive node
			if (active == false) {
				nodesCollection [i].transform.position = lastActivePosition;
			}
		}
	}
}
