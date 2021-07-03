using UnityEngine;
using System.Collections;

public class SoundUtility : MonoBehaviour {

	public static SoundUtility instance;
	public AudioSource TapMenuSFX;
	public AudioSource TapSFX;
	public AudioSource BenarSFX;
	public AudioSource SalahSFX;
	public AudioSource BeepSFX;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	public void PlayTapMenuSFX(){
		Debug.Log ("PLAY TAP MENU SFX");
		TapMenuSFX.Play ();
	}
	public void PlayTapSFX(){
		Debug.Log ("PLAY TAP SFX");
		TapSFX.Play ();
	}
	public void PlayBenarSFX(){
		Debug.Log ("PLAY BENAR SFX");
		BenarSFX.Play ();
	}
	public void PlaySalahSFX(){
		Debug.Log ("PLAY SALAH SFX");
		SalahSFX.Play ();
	}
	public void PlayBeepSFX(){
		Debug.Log ("PLAY BEEP SFX");
		BeepSFX.Play ();
	}
}
