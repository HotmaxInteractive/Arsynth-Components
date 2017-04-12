using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettingsMenu : MonoBehaviour {

	public AudioEchoFilter echo;
	public AudioChorusFilter chorus;
	public AudioReverbFilter reverb;

	public GameObject panel;
	public GameObject FXBtn;

	public void OpenMenu(){
		panel.SetActive (true);
		echo.decayRatio = .5f;
		echo.delay = 0;
		chorus.rate = 0;
		reverb.decayTime = 0;
		FXBtn.SetActive (false);
	}
	public void closeMenu(){
		panel.SetActive (false);
		FXBtn.SetActive (true);
	}
	public void goToCurrencyScreen(){
		SceneManager.LoadScene ("scenePicker");
	}
}
