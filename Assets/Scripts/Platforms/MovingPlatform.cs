using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	float platformSpeed = 1.6f;
	bool endpoint, isMoving;	
	public ScoreManager scoreManager;
	int MovePlatform;
	void Start () {
		scoreManager = GameObject.Find("HUD").GetComponent<ScoreManager>();
		if (scoreManager._score >= 50) {
			MovePlatform = Random.Range (1, 5);
		}
		if (scoreManager._score > 150) {
			MovePlatform = Random.Range (1, 4);
		}
		if (scoreManager._score > 250) {
			MovePlatform = Random.Range (1, 3);
		}
		if (scoreManager._score > 300) {
			MovePlatform = Random.Range (1, 2);
		}
		if (scoreManager._score > 500) {
			MovePlatform = 2;
		}

		switch (MovePlatform) 
		{
		case 1:

			break;
		case 2:
			isMoving = true;
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			break;
		}
	}
	void Update () {
		if (isMoving) {
			if(endpoint)
			{
				transform.position += Vector3.right * platformSpeed * Time.deltaTime;
			} 
			else
			{
				transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
			}

			if (transform.position.x>=1.22f)
			{
				endpoint = false;
			}
			if (transform.position.x<=-1.22f)
			{
				endpoint = true;
			}
		}

	}
}
