using UnityEngine;
using System.Collections;

public class HowToPlayManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1980f / 1080f;
	}
	public void BackToMainMenu(){
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadMainMenuScene",0.5f);
	}
	public void LoadMainMenuScene(){
		Application.LoadLevel ("MainMenu");
	}
}
