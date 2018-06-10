using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	//public Text scoreTxt;
	public int score, _score;
	public CameraFollow heightToScore;
	bool enableFallingRocks;
	public GameObject FallingRockSpawn, sc1,sc2,sc3,sc4,sc5;
	bool a;
	public int CurrentCoin;
	public Text coin_txt;
	// Use this for initialization
	void Start () {
		CheckCurrentCoin ();
	}
	
	// Update is called once per frame
	void Update () {
		//coin
		coin_txt.text = CurrentCoin.ToString();

		if (heightToScore.playerHeightY>=0) {
			if (heightToScore.playerHeightY > score) {
				score = (int)heightToScore.playerHeightY;
				_score = score * 10;
			}
			//scoreTxt.text = "Score : " + _score;
		}
		/*
		if (_score == 50) {
			if (!a) {
				sc1.SetActive (true);
				a = true;
			}
		}

		if (_score == 100) {
			if (a) {
				sc2.SetActive (true);
				a = false;
			}
		}

		if (_score == 150) {
			if (!a) {
				sc3.SetActive (true);
				a = true;
			}
		}

		if (_score == 200) {
			if (a) {
				sc4.SetActive (true);
				a = false;
			}
		}

		if (_score == 250) {
			if (!a) {
				sc5.SetActive (true);
				a = true;
			}
		}
*/

		/*if (_score >= 150) {
			if (!enableFallingRocks) {
				FallingRockSpawn.SetActive (true);
				enableFallingRocks = true;
			}
		}*/

	}

public void CheckCurrentCoin () {
	CurrentCoin = PlayerPrefs.GetInt ("Coin");
}

}
