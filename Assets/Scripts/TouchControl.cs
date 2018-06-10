using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public ButtonControl BTC;
	public PlayerMovement playerMovement;
	void Start () {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
	}

	void Update () {
	}
	public void OnPointerDown (PointerEventData eventData) {
		if (gameObject.name == "Left") {
			//float x = Mathf.Lerp(playerMovement.rb2d.velocity.x,-1f,100f);
			float x = -0.62f;
			//Debug.Log ("Touch left with :" + x);
			BTC.InputDirection = new Vector3 (x, 0, 0);
			BTC.InputDirection = (BTC.InputDirection.magnitude < -1) ? BTC.InputDirection.normalized*-1 : BTC.InputDirection;
		}
		if (gameObject.name == "Right") {
			//float x = Mathf.Lerp (playerMovement.rb2d.velocity.x,1f,100f);
			float x = 0.62f;
			//Debug.Log ("Touch right with :" + x);
			BTC.InputDirection = new Vector3 (x, 0, 0);
			BTC.InputDirection = (BTC.InputDirection.magnitude > 1) ? BTC.InputDirection.normalized : BTC.InputDirection;
		}
	}

	public void OnPointerUp (PointerEventData eventData){
		BTC.InputDirection = Vector3.zero;

	}
		
}
