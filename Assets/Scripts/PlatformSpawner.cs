using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
	public GameObject Platform, ShortPlatform, Cloud;

	public Transform SpawnedPlatform;
	public CameraFollow Cam;
	GameObject transform_1, transform_2, transform_3;
	private int platNumber;
	private float spawnPlatformTo, platCheck;
	// Use this for initialization
	void Start () {
		platCheck = -75;
	}
	
	// Update is called once per frame
	void Update () {
		if(Cam.playerHeightY > platCheck)
		{	
			PlatformManager();
		}
	}

	void PlatformManager()
	{
		platCheck = Cam.player.position.y + 15;
		SpawnPlatform(platCheck+15);
	}

	void SpawnPlatform (float FloatValue)
	{
		float y = spawnPlatformTo+0.5f;
		while (y<=FloatValue)
		{
			float x = Random.Range(-1.1f, 1.1f);
			platNumber = Random.Range (1,4);
			/*if(TheScore<30){
				platNumber = Random.Range (1,4);
			}
			else if (TheScore>30){
				platNumber = Random.Range (1,5);
			}*/

			Vector3 posXYZ = new Vector3 (x, y, 2);

			if (platNumber == 1) {
				//Instantiate (Platform, posXYZ, Quaternion.identity);
				transform_1 = Instantiate (Platform) as GameObject;
				transform_1.transform.SetParent (SpawnedPlatform, false);
				transform_1.transform.position = posXYZ;
			}
			if (platNumber == 2) {
				//Instantiate (ShortPlatform, posXYZ, Quaternion.identity);
				transform_2 = Instantiate (ShortPlatform) as GameObject;
				transform_2.transform.SetParent (SpawnedPlatform, false);
				transform_2.transform.position = posXYZ;
			}
			if (platNumber == 3) {
				//Instantiate (Cloud, posXYZ, Quaternion.identity);
				transform_3 = Instantiate (Cloud) as GameObject;
				transform_3.transform.SetParent (SpawnedPlatform, false);
				transform_3.transform.position = posXYZ;
			}
			y += Random.Range (.5f, 1.3f);
		}
		spawnPlatformTo = FloatValue;
	}
}
