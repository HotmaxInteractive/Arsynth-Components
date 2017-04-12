using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BillTracking : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	//public GameObject littleBuddy;
	public GameObject trackingScreen;
	bool onTracked;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	// tracks if a bill is detected. All stuff that happens on detection or lost goes here

	public void OnTrackableStateChanged( TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{

		// bill is detected 

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{

			onTracked = true;

			//littleBuddy.GetComponent<Animator>().SetBool("tracked", true);
			trackingScreen.GetComponent<Animator>().SetBool("tracked", true);

			//Renderer[] rendererComponents = littleBuddy.GetComponentsInChildren<Renderer>(true);
			//Collider[] colliderComponents = littleBuddy.GetComponentsInChildren<Collider>(true);
			//Canvas[] canvasComponents = littleBuddy.GetComponentsInChildren<Canvas>(true);

			// Enable Renderers
			/*foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			foreach (Canvas component in canvasComponents)
			{
				component.enabled = true;
			}*/

			StartCoroutine(doButtonJump ());

			fadeInVis ();



		}

		// bill is lost 

		else
		{

			onTracked = false;

			//littleBuddy.GetComponent<Animator>().SetBool("tracked", false);
			trackingScreen.GetComponent<Animator>().SetBool("tracked", false);

			//Renderer[] rendererComponents = littleBuddy.GetComponentsInChildren<Renderer>(true);
			//Collider[] colliderComponents = littleBuddy.GetComponentsInChildren<Collider>(true);
			//Canvas[] canvasComponents = littleBuddy.GetComponentsInChildren<Canvas>(true);

			// Disable rendering:
			/*foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}

			foreach (Canvas component in canvasComponents)
			{
				component.enabled = false;
			}*/

			setVisAnimIdle ();
		}
	}


	// activates the buttons animator to jump in sequence
	IEnumerator doButtonJump(){
		foreach (GameObject notebtn in GameObject.FindGameObjectsWithTag("notebtn")) {
			if (notebtn != null) {
				notebtn.GetComponent<Animator> ().SetTrigger ("buttonJump");
				yield return new WaitForSeconds (0.1f);
			}
		}
	}

	void fadeInVis(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			if (cube != null) {
				cube.GetComponent<Animator> ().SetTrigger ("tracked");
//				cube.GetComponent<Renderer> ().material.shader = Shader.Find("Standard");
			}
		}
	}

	// if tracking stops and animation clip is playing go back to idle state
	void setVisAnimIdle(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			if (cube != null) {
				cube.GetComponent<Animator> ().Play("Idle");
			}
		}
	}
}