using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {
	AudioSource pickup;
	// Use this for initialization
	void Start () {
		pickup = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			pickup.Play ();
			StartCoroutine (DestroyObject());
		}
	}

	IEnumerator DestroyObject () {
		yield return new WaitForSeconds (pickup.clip.length);
		gameObject.SetActive (false);
	} 
}
