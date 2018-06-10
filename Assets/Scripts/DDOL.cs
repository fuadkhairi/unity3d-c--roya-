using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour {
	bool isLoaded;
	void Awake ()  {
		if (!isLoaded) {
			DontDestroyOnLoad (gameObject);
			//Debug.Log ("DDOL:" + gameObject);
			isLoaded = true;
		}
	}
}
