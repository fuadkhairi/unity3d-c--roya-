using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using language;

public class GOUIControl : MonoBehaviour {
	Animator anim;
	public Text Highscore, MyScore, Cheers;
	int Current_highscore;
	public ScoreManager scoreManager;
	AudioSource restart;

	// Use this for initialization
	void Start () {
		restart = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		Current_highscore =  PlayerPrefs.GetInt ("Highscore",0);
		MyScore.text = language.Language.Default[5] + " : " + scoreManager._score;
		Highscore.text = "Last Highscore : " + Current_highscore;
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreManager._score > Current_highscore) {
			PlayerPrefs.SetInt ("Highscore", scoreManager._score);

			Cheers.text = language.Language.Default[8];
		}
	}

	void RestartGame () {
		SceneManager.LoadScene ("Gameplay");
	}

	public void GameOverRestart() {
		restart.Play ();
		anim.SetTrigger ("Restart");
	}
}
