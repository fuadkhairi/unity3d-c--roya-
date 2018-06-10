using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
	public float Speed = 1f;
	Vector3 StartPoint;
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		StartPoint = GetComponentInParent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.right * Speed * Time.deltaTime);
		rb2d.velocity = new Vector3 (Speed*Time.deltaTime, 0, 0);
	}

	private void OnBecameInvisible () {
		transform.position = StartPoint;
	}
}
