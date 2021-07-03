using UnityEngine;
using System.Collections;

public class DestroyMark : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyThisGameObject",1f);
	}
	public void DestroyThisGameObject(){
		Destroy (this.gameObject);
	}
}
