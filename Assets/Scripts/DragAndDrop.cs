using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	Vector3 dist;
	float posX;
	float posY;
	float originalPositionX;
	float originalPositionY;
	bool isDrag;
	public int speedType; //1: pelan, 2: medium, 3: cepat
	public JudgeCollider jc;
	public MainGameManager mgm;

	void OnMouseDown(){
		isDrag = true;
		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
		SoundUtility.instance.PlayTapSFX();
	}
	void OnMouseDrag(){
		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.position = worldPos;
	}
	void OnMouseUp(){
		isDrag = false;
		jc.Judge ();
	}
	void Start () {
		mgm = GameObject.Find ("MainGameManager").GetComponent<MainGameManager>();
		if(mgm.layer == 0){
			Debug.Log ("SET LAYER 4");
			GetComponent<SpriteRenderer>().sortingOrder = 4;
		}else{
			Debug.Log ("SET LAYER 6");
			GetComponent<SpriteRenderer>().sortingOrder = 6;
		}
		isDrag = false;
		speedType = mgm.speedType;
		Camera.main.aspect = 1980f / 1080f;
	}
	void Update(){
		if(!isDrag){
			this.transform.Translate((Vector2.left * speedType) * Time.deltaTime);
			originalPositionX = this.transform.localPosition.x;
			originalPositionY = this.transform.localPosition.y;
		}
	}
	public void SetSpeedType(int speed){
		this.speedType = speed;
	}
	public void returnTrashToPosition(){
		this.transform.localPosition = new Vector2 (originalPositionX, originalPositionY);
	}
}
