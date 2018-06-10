using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	public float playerHeightY,
	parallaxSpeed,
	parallaxSpeed2,
	ReflectionSpeed,
	shakeTimer,
	shakeAmount;

	public Transform player,
	mainCamera, 
	bgParallax, 
	bgParallaxFront,
	Reflection;

	float lastCameraY;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		mainCamera = Camera.main.transform;
		lastCameraY = mainCamera.position.y;
		//player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//Parallax
		float deltaX = mainCamera.transform.position.y - lastCameraY;
		bgParallax.transform.position+=Vector3.down*(deltaX*parallaxSpeed);
		bgParallaxFront.transform.position+=Vector3.down*(deltaX*parallaxSpeed2);
		Reflection.transform.position+=Vector3.down*(deltaX*ReflectionSpeed);
		lastCameraY = mainCamera.transform.position.y;


		playerHeightY = player.position.y;
		float currCameraHeight = transform.position.y;
		float newHeightCam = Mathf.Lerp (currCameraHeight, playerHeightY, Time.deltaTime * 5);
		if (playerHeightY > currCameraHeight) 
		{
			transform.position = new Vector3 (transform.position.x, newHeightCam, transform.position.z);
		}

		//shake teh camera
		if (shakeTimer >= 0) {
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		} else {
			transform.position = new Vector3 (0, transform.position.y, transform.position.z);
		}
		
	}

	public void ShakeCamera (float shakePwr, float shakeDur) {
		shakeTimer = shakeDur;
		shakeAmount = shakePwr;
	}
}
