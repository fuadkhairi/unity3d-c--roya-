using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPlatform : MonoBehaviour {
	float fallSpeed = 0.15f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * fallSpeed * Time.deltaTime;
	}
}
