using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float fireRate;
	float lastShot;
	Rigidbody2D rb2D;
	public bool isDead;


	void Start () {
		speed =  10.0f;
		fireRate = .5f;
		isDead = false;
		rb2D = gameObject.GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if (!isDead) {
			rb2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, 0f);
			if (Input.GetAxis ("Fire1") != 0) {
				//StopCoroutine ("Fire");
				//StartCoroutine ("Fire");
				Fire();
			}
		}

	}
	void OnCollisionEnter2D(Collider2D other){
		if (other.CompareTag("Asteriod")){
			isDead = true;

		}
	}
	void Fire(){
		//yield return new WaitForSeconds(.1f);
		if(Time.time>fireRate+lastShot){
			GameObject go = (GameObject)Instantiate (Resources.Load ("Bullet"),transform.position,transform.rotation);
			lastShot = Time.time;
		}
	}
}
