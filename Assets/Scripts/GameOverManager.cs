using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public Text tepatCounterText;
	public Text salahCounterText;
	public Text TotalNilaiCounterText;
	public GameObject PanelGetBook;
	public GameObject Book;
	public GameObject BannerBook;
	public GameObject ButtonNext;
	public GameObject ButtonRetry;

	int isGetBook;
	bool isClicked;
	// Use this for initialization
	void Start () {
		isClicked = false;
		ButtonNext.SetActive(false);
		ButtonRetry.SetActive(false);
		Camera.main.aspect = 1980f / 1080f;
		tepatCounterText.text = ""+PlayerPrefs.GetInt ("benar");
		salahCounterText.text = ""+PlayerPrefs.GetInt ("salah");
		TotalNilaiCounterText.text = ""+PlayerPrefs.GetInt ("score");
		isGetBook = PlayerPrefs.GetInt ("isGetBook");
		if (isGetBook == 0) {
			PlayerPrefs.SetInt ("isGetBook", 1);
			Invoke ("GetBook", 1f);
			PlayerPrefs.Save ();
		} else {
			ButtonNext.SetActive(true);
			ButtonRetry.SetActive(true);
		}
	}

	public void GetBook(){
		PanelGetBook.SetActive (true);
		Book.SetActive (true);
		BannerBook.SetActive (true);
		Invoke ("SetIsClicked",1f);
	}
	public void BookClicked(){
		if(isClicked){
			SoundUtility.instance.PlayTapMenuSFX ();
			PanelGetBook.SetActive (false);
			ButtonNext.SetActive(true);
			ButtonRetry.SetActive(true);
		}
	}
	public void SetIsClicked(){
		isClicked = true;
	}
	public void PlayAgain(){
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadMainGameScene", 0.5f);
	}
	public void Next(){
		SoundUtility.instance.PlayTapMenuSFX();
		Invoke ("LoadMainMenuScene", 0.5f);
	}
	public void LoadMainGameScene(){
		Application.LoadLevel ("MainGame");
	}
	public void LoadMainMenuScene(){
		Application.LoadLevel ("MainMenu");
	}
}
