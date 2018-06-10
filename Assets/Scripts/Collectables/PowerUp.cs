using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	AudioSource pickup;
	Rigidbody2D player;
	// Use this for initialization
	void Start () {
		pickup = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player"&&player.velocity.y<=0) {
			pickup.Play ();
			StartCoroutine (DestroyObject());
		}
	}

	IEnumerator DestroyObject () {
		yield return new WaitForSeconds (pickup.clip.length);
		gameObject.SetActive (false);
	} 
}
