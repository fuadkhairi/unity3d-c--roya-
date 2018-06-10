using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour {
	public GameObject Apple, Cherry, Gold, Grape, Silver; 
	int ToSpawn;
	int apple, cherry, grape;
	// Use this for initialization
	void Start () {
		apple = PlayerPrefs.GetInt ("tier1",0);
		cherry = PlayerPrefs.GetInt ("tier2",0);
		grape = PlayerPrefs.GetInt ("tier3",0);
		ToSpawn = Random.Range (1, 10);

		if (ToSpawn == 1) {
			Gold.SetActive (true);
		}
		if (ToSpawn == 2) {
			Silver.SetActive (true);
		}
		if (ToSpawn == 3&&apple==1) {
				Apple.SetActive (true);
		}
		if (ToSpawn == 4&&cherry==1) {
				Grape.SetActive (true);
		}
		if (ToSpawn == 5&&grape==1) {
				Cherry.SetActive (true);
		}

	}
		
}
