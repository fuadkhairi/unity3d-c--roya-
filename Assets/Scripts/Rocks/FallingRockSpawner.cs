using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour {
	public GameObject FallingRock, SpawnedRocks;
	GameObject spawn;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnRocks",0,3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnRocks () {
		float x = Random.Range(-1.1f, 1.1f);
		Vector3 posXYZ = new Vector3 (x, SpawnedRocks.transform.position.y, SpawnedRocks.transform.position.z);
		FallingRock.SetActive (true);
		FallingRock.transform.SetParent (SpawnedRocks.transform, false);
		FallingRock.transform.position = posXYZ;
		//spawn = Instantiate (FallingRock) as GameObject;
		//spawn.transform.SetParent (SpawnedRocks.transform, false);
		//spawn.transform.position = posXYZ;
		//yield return new WaitForSeconds (1);
	}
}
