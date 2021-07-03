using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public GameObject panelConfirmExit;
	public GameObject buttonBook;
	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1980f / 1080f;
		if(PlayerPrefs.GetInt("isGetBook") == 1){
			buttonBook.SetActive(true);
		}
	}
	public void ButtonBook(){
		Debug.Log ("Load Scene Guide Book");
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadGuideBookScene",0.5f);
	}
	public void LoadGuideBookScene(){
		Application.LoadLevel ("GuideBook");
	}
	public void StartGame(){
		Debug.Log ("Load Scene Main Game");
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadSceneMainGame",0.5f);
	}
	public void HowToPlay(){
		Debug.Log ("Load Scene How To Play");
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadSceneHowToPlay",0.5f);
	}
	public void LoadSceneMainGame(){
		Application.LoadLevel ("MainGame");
	}
	public void LoadSceneHowToPlay(){
		Application.LoadLevel ("HowToPlay");
	}
	public void ConfirmExitGame(){
		SoundUtility.instance.PlayTapMenuSFX();
		Debug.Log ("Confirm Exit Game");
		panelConfirmExit.SetActive (true);
	}
	public void YesExitGame(){
		SoundUtility.instance.PlayTapMenuSFX();
		Debug.Log ("Exit Game");
		Application.Quit ();
	}
	public void NoExitGame(){
		SoundUtility.instance.PlayTapMenuSFX();
		Debug.Log ("Cancel Exit Game");
		panelConfirmExit.SetActive (false);
	}
}
