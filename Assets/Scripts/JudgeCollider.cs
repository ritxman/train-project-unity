using UnityEngine;
using System.Collections;

public class JudgeCollider : MonoBehaviour {

	public int type;
	public int TrueOrFalse;
	public int TrashSelected;
	public GameObject parent;
	public DragAndDrop DragAndDropAtParent;

	void Start(){
		parent = transform.parent.gameObject;
		DragAndDropAtParent = parent.GetComponent<DragAndDrop>();
	}
	public void Judge(){
		if(TrueOrFalse == 0){
			DragAndDropAtParent.returnTrashToPosition();
		}else if(TrueOrFalse == 1){
			Debug.Log ("BENAR");
			SoundUtility.instance.PlayBenarSFX();
			DragAndDropAtParent.mgm.AddScore(TrashSelected);
			Destroy(parent);
		}else if(TrueOrFalse == 2){
			Debug.Log ("SALAH");
			SoundUtility.instance.PlaySalahSFX();
			DragAndDropAtParent.mgm.MinScore(TrashSelected);
			Destroy(parent);
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "Tempat Sampah 1 Plastik") { //type = 1
			TrashSelected = 1;
			if (type == 1) {
				TrueOrFalse = 1;
			} else {
				TrueOrFalse = 2;
			}
		} else if (coll.gameObject.name == "Tempat Sampah 2 Kertas") { //type = 2
			TrashSelected = 2;
			if (type == 2) {
				TrueOrFalse = 1;
			} else {
				TrueOrFalse = 2;
			}
		} else if (coll.gameObject.name == "Tempat Sampah 3 Organik") { //type = 3
			TrashSelected = 3;
			if (type == 3) {
				TrueOrFalse = 1;
			} else {
				TrueOrFalse = 2;
			}
		} else if(coll.gameObject.name == "EndTrashBoundary"){
			Destroy (parent);
		} else {
			TrueOrFalse = 0;
		}
	}

}
