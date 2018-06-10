using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortBehave : MonoBehaviour {
	int lifes;
	Animator anim;
	public PlayerMovement playerMovement;
	AudioSource hit;
	// Use this for initialization
	void Start () {
		lifes = 2;
		anim = GetComponent<Animator> ();
		hit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource> ();
		playerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update () {
		anim.SetInteger ("Lifes", lifes);
		if (lifes <= 0) {
			hit.Play ();
			StartCoroutine ("hideObject");
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player"&& playerMovement.rb2d.velocity.y<=-1.5f) {
			lifes--;
			//Debug.Log ("Hit the " + col.name);
		}

		if (col.tag == "EndTrigger") {
			gameObject.SetActive (false);
			//Debug.Log ("Hit with the " + col.name);
		}
	}

	IEnumerator hideObject () {
		yield return new WaitForSeconds (0.1f);	
		gameObject.SetActive (false);
	}
}
