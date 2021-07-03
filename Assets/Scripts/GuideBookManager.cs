using UnityEngine;
using System.Collections;

public class GuideBookManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1980f / 1080f;
	}

	public void BackToMainMenu(){
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadSceneMainMenu",0.5f);
	}
	public void LoadSceneMainMenu(){
		Debug.Log ("Load Scene Main Menu");
		Application.LoadLevel ("MainMenu");
	}
}
