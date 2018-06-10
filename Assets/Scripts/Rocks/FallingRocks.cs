using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour {
	int rotateSpeed;
	// Use this for initialization
	void Start () {
		rotateSpeed = Random.Range (-5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * rotateSpeed);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "EndTrigger") {
			gameObject.SetActive (false);
		}
	}
}
