using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour {
	public bool interstitial_show;
	// Use this for initialization
	void Start () {
		interstitial_show = false;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
