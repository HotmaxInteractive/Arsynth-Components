using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject> ();
	private GameObject[] touchesOld;
	RaycastHit hit;

	void Update () {

		//-----------------------------------------------------
		// 					UNITY EDITOR
		//-----------------------------------------------------

		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear ();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, touchInputMask)) {

				GameObject reciever = hit.transform.gameObject;
				touchList.Add (reciever);

				if (Input.GetMouseButtonDown(0)) {
					reciever.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonUp(0)) {
					reciever.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButton(0)) {
					reciever.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			} 
		}

		//-----------------------------------------------------
		// 							END
		//-----------------------------------------------------

		if (Input.touchCount > 0) {

			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear ();

			foreach (Touch touch in Input.touches) {

				Ray ray = Camera.main.ScreenPointToRay (touch.position);

				if (Physics.Raycast (ray, out hit, touchInputMask)) {

					GameObject reciever = hit.transform.gameObject;
					touchList.Add (reciever);

					if (touch.phase == TouchPhase.Began) {
						reciever.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Ended) {
						reciever.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Stationary) {
						reciever.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
					}
					if (touch.phase == TouchPhase.Canceled) {
						reciever.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			} 
		}
	}
}
