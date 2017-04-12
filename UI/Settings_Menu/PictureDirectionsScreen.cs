using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureDirectionsScreen : MonoBehaviour {

	public Text directionsTextBtn;

	public void changeText(){
		directionsTextBtn.text = "Show pics of how to play";
	}
}
