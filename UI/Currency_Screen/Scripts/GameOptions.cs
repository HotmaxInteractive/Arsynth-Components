using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {

	public string sceneName;

	public void setScene (string scene) {
		sceneName = scene;
		gameObject.transform.FindChild(scene).GetComponent<Animator>().SetTrigger("Active");
	}
	public void loadScene () {
		SceneManager.LoadScene (sceneName);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
