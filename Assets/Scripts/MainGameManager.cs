using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGameManager : MonoBehaviour {

	public Text TimerText;
	public Text ReadyText;
	public Text ScoreText;
	public GameObject [] sampah = new GameObject[10];
	public GameObject CorrectMark;
	public GameObject WrongMark;
	public Color RedText;

	public int randomType;
	public int speedType;
	public int layer;
	public int TimerCount;
	public int score;
	public int benar;
	public int salah;
	public float delayRespawn;
	public float RespawnYCoordinate;
	// Use this for initialization
	void Start(){
		Camera.main.aspect = 1980f / 1080f;
		score = 0;
		benar = 0;
		salah = 0;
		TimerCount = 60;
		delayRespawn = 3f;
		RedText = new Color ();
		RedText.r = 255f;
		RedText.g = 0f;
		RedText.b = 0f;
		RedText.a = 255f;
		Invoke ("SetReadyText",1.5f);
	}
	public void SetReadyText(){
		ReadyText.text = "SIAP";
		Invoke ("SetGoText",1f);
	}
	public void SetGoText(){
		ReadyText.text = "MULAI";
		Invoke ("StartTimer",1f);
	}
	public void StartTimer(){
		ReadyText.gameObject.SetActive (false);
		StartCoroutine (TimerDown());
		StartCoroutine (RespawnTrash());
	}
	public void AddScore(int TrashType){
		if (TrashType == 1) {
			Instantiate (CorrectMark, new Vector2 (-5.31f, 4.96f), Quaternion.identity);
		} else if (TrashType == 2) {
			Instantiate (CorrectMark, new Vector2 (-0.15f, 4.97f), Quaternion.identity);
		} else if (TrashType == 3) {
			Instantiate (CorrectMark, new Vector2 (5.12f, 4.97f), Quaternion.identity);
		}
		score++;
		benar++;
		ScoreText.text = "SCORE: \n"+score;
	}
	public void MinScore(int TrashType){
		if (TrashType == 1) {
			Instantiate (WrongMark, new Vector2 (-5.31f, 4.96f), Quaternion.identity);
		}else if (TrashType == 2){
			Instantiate (WrongMark, new Vector2 (-0.15f, 4.97f), Quaternion.identity);
		}else if (TrashType == 3) {
			Instantiate (WrongMark, new Vector2 (5.12f, 4.97f), Quaternion.identity);
		}
		score--;
		salah++;
		ScoreText.text = "SCORE: \n"+score;
	}
	IEnumerator TimerDown(){
		while(true){
			TimerCount--;
			TimerText.text = "WAKTU: \n"+TimerCount;
			if(TimerCount <= 10){
				TimerText.color = RedText;
				SoundUtility.instance.PlayBeepSFX();
			}
			if(TimerCount == 0){
				PlayerPrefs.SetInt("score",score);
				PlayerPrefs.SetInt("benar",benar);
				PlayerPrefs.SetInt("salah",salah);
				PlayerPrefs.Save();
				Application.LoadLevel ("GameOver");
			}
			yield return new WaitForSeconds(1f);
		}
	}
	IEnumerator RespawnTrash(){
		while(true){
			/*
				4 kertas koran: layer 4 -1.79, layer 6 -3.8
				3 ranting pohon: layer 4 -0.88, layer 6 -3.05
				2 kardus: layer 4 -1.61, layer 6 -3.39
				1 kantong kresek: layer 4 -1, layer 6 -2.8
				0 botol plastik: layer 4 -1, layer 6 -3
			 */
			if(TimerCount > 30){
				speedType = Random.Range(1,3);
				delayRespawn = 2f;
			}else{
				speedType = Random.Range(2,4);
				delayRespawn = 1f;
			}
			randomType = Random.Range(0,5);
			layer = Random.Range (0,2);
			if(randomType == 0){
				if(layer == 0){
					RespawnYCoordinate = -1f;
				}else{
					RespawnYCoordinate = -3f;
				}
			}else if(randomType == 1){
				if(layer == 0){
					RespawnYCoordinate = -1f;
				}else{
					RespawnYCoordinate = -2.8f;
				}
			}else if(randomType == 2){
				if(layer == 0){
					RespawnYCoordinate = -1.61f;
				}else{
					RespawnYCoordinate = -3.39f;
				}
			}else if(randomType == 3){
				if(layer == 0){
					RespawnYCoordinate = -0.88f;
				}else{
					RespawnYCoordinate = -3.05f;
				}
			}else if(randomType == 4){
				if(layer == 0){
					RespawnYCoordinate = -1.79f;
				}else{
					RespawnYCoordinate = -3.8f;
				}
			}
			Debug.Log ("randomType: "+randomType+", speedType:"+speedType);
			Debug.Log ("layer: "+layer);
			Instantiate(sampah[randomType], new Vector2(14f,RespawnYCoordinate), Quaternion.identity);
			yield return new WaitForSeconds(delayRespawn);
		}
	}
	void Update(){

	}
}
