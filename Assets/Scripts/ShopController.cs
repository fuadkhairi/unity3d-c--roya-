using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
	public Text Coin_txt, Notif;
	int MyCoin, currentPlayer;
	//public Button AppleBtn, CherryBtn, GrapeBtn, Player1Btn, Player2Btn;

	public GameObject ShopPanel, ControlPanel, DefaultPanel;

	public Text AppleBtnTXT, CherryBtnTXT, GrapeBtnTXT, Player1BtnTXT, Player2BtnTXT;
	public AudioSource Buy, Select, Wrong, Click;



	//bool AppleSold, CherrySold, GrapeSold, Player2Sold;
	//REMEMBER CHERRY IS GRAPE AND GRAPE IS CHERRYYYYY!!!!
	int apple, cherry, grape, player2IsAvailable;
	public GameObject Player1, Player2;



	// Use this for initialization
	void Start () {
//			PlayerPrefs.DeleteAll ();
			PlayerPrefs.SetInt("Coin", 5000);
//			CollectableTier = PlayerPrefs.GetInt ("Tier", 0);
		currentPlayer = PlayerPrefs.GetInt ("Player",1);
		MyCoin = PlayerPrefs.GetInt ("Coin", 0);
		apple = PlayerPrefs.GetInt ("tier1",0);
		cherry = PlayerPrefs.GetInt ("tier2",0);
		grape = PlayerPrefs.GetInt ("tier3",0);
		player2IsAvailable = PlayerPrefs.GetInt ("Player2",0);
	}
	
	// Update is called once per frame
	void Update () {
		Coin_txt.text = MyCoin.ToString ();

		if (currentPlayer == 1) {
			Player1.SetActive (true);
			Player2.SetActive (false);
			Player1BtnTXT.text="USED";
			if(player2IsAvailable==1)
			Player2BtnTXT.text="USE";
		}
		if (currentPlayer == 2) {
			Player1.SetActive (false);
			Player2.SetActive (true);
			Player1BtnTXT.text="USE";
			if(player2IsAvailable==1)
			Player2BtnTXT.text="USED";
		}

		if (apple == 1) {
			AppleBtnTXT.text="SOLD";
		}

		if (cherry == 1) {
			CherryBtnTXT.text="SOLD";
		}

		if (grape == 1) {
			GrapeBtnTXT.text="SOLD";
		}



	}

	public void selectPlayer1 (){
		currentPlayer=1;
		PlayerPrefs.SetInt("Player",1);
		Player1BtnTXT.text="USED";
		Click.Play ();
		if (player2IsAvailable == 1) {
			Player2BtnTXT.text = "USE";
		}
	}

	public void selectPlayer2 (){
		player2IsAvailable = PlayerPrefs.GetInt ("Player2",0);
		if (player2IsAvailable==1) {
			currentPlayer = 2;
			Click.Play ();
			PlayerPrefs.SetInt ("Player", 2);
			Player1BtnTXT.text = "1";
			Player2BtnTXT.text = "USED";
		} else if (player2IsAvailable==0) {
			if (MyCoin >= 300) {
				Buy.Play ();
				MyCoin = MyCoin - 300;
				PlayerPrefs.SetInt ("Player2",1);
				Player2BtnTXT.text = "USE";
				player2IsAvailable = PlayerPrefs.GetInt ("Player2",0);
			} else {
				Wrong.Play ();
				StartCoroutine (NotificationFailed());
			}
		}
	}

	public void BuyApple () {
		if (apple==0) {
			if (MyCoin >= 50) {
				MyCoin = MyCoin - 50;
				AppleBtnTXT.text = "SOLD";
				Buy.Play ();
				PlayerPrefs.SetInt ("tier1", 1);
				PlayerPrefs.SetInt ("Coin", MyCoin);
				apple = PlayerPrefs.GetInt ("tier1", 0);
			} else {
				Wrong.Play ();
				StartCoroutine (NotificationFailed());
			}
		}
	}

	public void BuyCherry () {
		if (cherry==0) {
			if (MyCoin >= 300) {
				Buy.Play ();
				MyCoin = MyCoin - 300;
				CherryBtnTXT.text="SOLD";
				PlayerPrefs.SetInt ("tier2", 1);
				PlayerPrefs.SetInt ("Coin", MyCoin);
				cherry = PlayerPrefs.GetInt ("tier2",0);
			} else {
				Wrong.Play ();
				StartCoroutine (NotificationFailed());
			}
		}
	}

	public void BuyGrape () {
		if (grape==0) {
			if (MyCoin >= 150) {
				Buy.Play ();
				MyCoin = MyCoin - 150;
				GrapeBtnTXT.text="SOLD";
				PlayerPrefs.SetInt ("tier3", 1);
				PlayerPrefs.SetInt ("Coin", MyCoin);
				grape = PlayerPrefs.GetInt ("tier3",0);
			} else {
				Wrong.Play ();
				StartCoroutine (NotificationFailed());
			}
		}
	}

	IEnumerator NotificationFailed () {
		Notif.text = "Not enough coins!";
		yield return new WaitForSeconds (0.1f);
		Notif.text = "";
		yield return new WaitForSeconds (0.1f);
		Notif.text = "Not enough coins!";
		yield return new WaitForSeconds (0.1f);
		Notif.text = "";
		yield return new WaitForSeconds (0.1f);
		Notif.text = "Not enough coins!";
		yield return new WaitForSeconds (0.1f);
		Notif.text = "";
	}

	public void OpenShopPanel () {
		DefaultPanel.SetActive (false);
		ShopPanel.SetActive (true);
		ControlPanel.SetActive (false);
		Click.Play ();
	}

	public void OpenControlPanel () {
		DefaultPanel.SetActive (false);
		ShopPanel.SetActive (false);
		ControlPanel.SetActive (true);
		Click.Play ();
	}

	public void BackToDefaultPanel () {
		DefaultPanel.SetActive (true);
		ShopPanel.SetActive (false);
		ControlPanel.SetActive (false);
		Click.Play ();
	}

	public void setControllerJoystick () {
		PlayerPrefs.SetInt ("Control", 0);
		Click.Play ();
		BackToDefaultPanel ();
	}
	public void setControllerTouch () {
		PlayerPrefs.SetInt ("Control", 1);
		Click.Play ();
		BackToDefaultPanel ();
	}
	public void setControllerAccelerometer () {
		PlayerPrefs.SetInt ("Control", 2);
		Click.Play ();
		BackToDefaultPanel ();
	}

}
