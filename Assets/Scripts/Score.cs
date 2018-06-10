using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using language;

public class Score : MonoBehaviour {
	public static Score instance;
	TextMesh TXTScore;
	public ScoreManager score_manager;
	public GameManager game_manager;
	public bool isJumping;
	// Use this for initialization
	void Awake () {
		instance = this;
	}
	void Start () {
		TXTScore = GetComponent<TextMesh> ();
		GetComponent<MeshRenderer>().sortingLayerName="Default";
		GetComponent<MeshRenderer>().sortingOrder=100;
	}
	
	// Update is called once per frame
	void Update () {
		if (game_manager.gameState == GameManager.GameState.GamePlay) {
			if (!isJumping) {
				TXTScore.text = language.Language.Default[3];
			} else {
				TXTScore.text = score_manager._score.ToString();
			}
		}
	}
}
