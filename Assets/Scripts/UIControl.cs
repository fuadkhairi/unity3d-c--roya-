using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using language;

public class UIControl : MonoBehaviour {
	public GameManager gameManager;
	public ScoreManager scoreManager;
	public Text Highscore;
	int Current_highscore;
	Animator anim;
	AudioSource start;
	bool OpenShop;
	public Text Shop;
	public AudioSource Click;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Current_highscore =  PlayerPrefs.GetInt ("Highscore",0);
		Highscore.text = ""+ Current_highscore;
		start = GetComponent<AudioSource> ();
	}

	public void GameMenuToPlay() {
		anim.SetTrigger ("Play");
		start.Play ();
	}

	public void ShopUI () {
		if (!OpenShop) {
			anim.SetTrigger ("OpenShop");
			OpenShop = true;
			Shop.text="CLOSE";
			Click.Play ();
		} else {
			anim.SetTrigger ("QuitShop");
			OpenShop = false;
			Click.Play ();
			Shop.text="OPTIONS";
		}
	}

	public void isPlaying () {
		gameManager.gameState = GameManager.GameState.GamePlay;
	}

	public void isBackToMenu () {
		gameManager.gameState = GameManager.GameState.GameMenu;
	}

	public void isOver () {
		gameManager.gameState = GameManager.GameState.GameOver;
	}
	public void disablePanel () {
		Panel.SetActive (false);
	}
}
