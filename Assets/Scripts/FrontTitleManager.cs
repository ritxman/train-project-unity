using UnityEngine;
using System.Collections;

public class FrontTitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1980f / 1080f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("Load Scene Main Menu");
			SoundUtility.instance.PlayTapMenuSFX();
			Invoke ("GoToMainMenu",0.5f);
		}
	}
	public void GoToMainMenu(){
		Application.LoadLevel("MainMenu");
	}
}
