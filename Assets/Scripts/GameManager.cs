using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	bool enableBannerAd, disableBannerAd;
	public static GameManager instance;
	public ScoreManager scm;
	bool CheckingScore, showIntersititial, showBanner;
	public enum GameState {
		GameMenu, GamePlay, GamePause, GameOver
	};


	public GameState gameState = GameState.GameMenu;
	Vector3 camOriginal;
	public Transform cams;
	public GameObject HUD, MenuUI, GOUI, Joystick;

	void Awake () {
		//AppLovin.SetSdkKey ("6WTLcebeJbe5vNg7UfkTsWcMzJMvPhpVCMsp_RSI25NxT32yimPTH1wFKG9lyzF9J5zIXPbZV-Vz1TvlJJIaKC");
	//OnStartApplovin();
	}
	void Start () {
		//Chartboost.cacheRewardedVideo (CBLocation.Default);
		camOriginal = new Vector3 (cams.transform.position.x, 1.59f, cams.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState == GameState.GameMenu) {
			//Show AppLovin Banner
	//	ApplovinShowBanner();
			MenuUI.SetActive (true);
			GOUI.SetActive (false);
			Joystick.SetActive (false);
			HUD.SetActive (false);
			if (Input.GetKeyDown (KeyCode.Escape)){
				ExitGame ();
			}
		} else if (gameState == GameState.GamePlay) {
			if (!CheckingScore) {
				scm.CheckCurrentCoin ();
				CheckingScore = true;
			}
			//disable Applovin Banner
	//	ApplovinHideBanner();
			MenuUI.SetActive (false);
			GOUI.SetActive (false);
			HUD.SetActive (true);
		} else if (gameState == GameState.GameOver) {
	//	ApplovinShowInterstitial ();
			//Chartboost.showRewardedVideo (CBLocation.Default);
			MenuUI.SetActive (false);
			GOUI.SetActive (true);
			HUD.SetActive (false);
			Joystick.SetActive (false);
		}
	}

	public void PlaytheGame () {
		gameState = GameState.GamePlay;
	} 
	public void GamePause () {
		gameState = GameState.GamePause;
	}
	public void GameMenu () {
		gameState = GameState.GameMenu;
	}
	public void GameOver () {
		gameState = GameState.GameOver;
	}
	public void RestartGame () {
		SceneManager.LoadScene ("Gameplay"); 
	}
	public void ExitGame () {
		Application.Quit ();
	}

	public void OnClickVideoAds () {
		Debug.Log ("Clicked Video Ad!");
	}
	void OnStartApplovin()
	{
	    #if UNITY_ANDROID
		AppLovin.InitializeSdk ();
		AppLovin.PreloadInterstitial();
		#endif
	}

	void ApplovinShowBanner ()
	{
			if (!showBanner) {
			//AppLovin.ShowAd (AppLovin.AD_POSITION_CENTER,AppLovin.AD_POSITION_TOP);
			showBanner = true;
			}
	}

	void ApplovinShowInterstitial ()
	{
			if (!showIntersititial) {
				//AppLovin.ShowInterstitial ();
				showIntersititial = true;
			}
	}

	void ApplovinHideBanner ()
	{
		if (!disableBannerAd)
		{
			AppLovin.HideAd();
			disableBannerAd=true;
		}
		
	}
}
