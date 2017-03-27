using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	Renderer rend;
	void Start () {
		rend = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0f,10f*Time.deltaTime,0f));

	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}

}
