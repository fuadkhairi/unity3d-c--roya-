using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBehave : MonoBehaviour {
	int lifes;
	Animator anim;
	AudioSource hit;
	public PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
		lifes = 3;
		hit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
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
		//playerMovement.rb2d.velocity.y<-0.2f
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
