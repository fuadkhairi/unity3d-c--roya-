using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehave : MonoBehaviour {
	public PlayerMovement playerMovement;
	AudioSource hit;
	// Use this for initialization
	void Start () {
		hit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource> ();
		playerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player"&& playerMovement.rb2d.velocity.y<=-1.5f) {
			StartCoroutine ("hideObject");
			//Debug.Log ("Hit the " + col.name);
		}

		if (col.tag == "EndTrigger") {
			gameObject.SetActive (false);
			//Debug.Log ("Hit with the " + col.name);
		}
	}

	IEnumerator hideObject () {
		hit.Play ();
		yield return new WaitForSeconds (0.1f);	
		gameObject.SetActive (false);
	}
}
