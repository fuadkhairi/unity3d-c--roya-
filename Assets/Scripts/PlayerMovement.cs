using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public ScoreManager scoreManager;
	//variables declared
	public Rigidbody2D rb2d;
	Animator anim;
	float playerSpeed = 4.0f;
	float playerJump = 300f;
	public bool grounded, PlayerIsJumping, saveCoinOnce, checkControlOnce;
	public Transform groundCheck;
	public float groundRadius=.2f;
	public LayerMask Ground;
	Vector2 move;
	AudioSource jump;
	public CameraFollow camera;
	public GameManager gameManager;
	public GameObject JumpParticle, Camera;
	//joystick
	public VirtualJoystick moveJoystick;
	public ButtonControl touchControl;

	public AudioSource Spring_FX;

	public enum ControlType {
		Joystick, Accelerometer, Touch
	};
	public ControlType CT;
	public GameObject JoystickController, TouchController;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		jump = GetComponent<AudioSource> ();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		//checking whenever player are grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, Ground);
	}

	void FixedUpdate () {
		


		if (gameManager.gameState==GameManager.GameState.GameMenu) {
			float velocity_y = rb2d.velocity.y;
			if (grounded && velocity_y <= 0) {
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, playerJump));
			}
			if (velocity_y > 5) {
				velocity_y = 5;
			}
		}


		if (gameManager.gameState==GameManager.GameState.GamePlay) {
			if (!checkControlOnce) {
				int Controller = PlayerPrefs.GetInt ("Control",0);
				if (Controller == 0) {
					CT = ControlType.Joystick;
					JoystickController.SetActive (true);
					TouchController.SetActive (false);
				} else if (Controller == 1) {
					CT = ControlType.Touch;
					JoystickController.SetActive (false);
					TouchController.SetActive (true);
				} else {
					CT = ControlType.Accelerometer;
					JoystickController.SetActive (false);
					TouchController.SetActive (false);
				}
				checkControlOnce = true;
			}

			//joystick
			if (CT == ControlType.Joystick) {
				
				//X axes of movement
				move = new Vector2 (moveJoystick.InputDirection.x, moveJoystick.InputDirection.x);
				if (move != Vector2.zero) {
					anim.SetBool ("isMoving", true);
					anim.SetFloat ("vel_x", move.x);
					anim.SetFloat ("vel_y", rb2d.velocity.y);
				} else {
					anim.SetBool ("isMoving", false);
				}
				rb2d.velocity = new Vector2 (move.x * playerSpeed, rb2d.velocity.y);

				float velocity_y = rb2d.velocity.y;
				if (grounded && velocity_y <= 0) {
					rb2d.velocity = new Vector2 (0, 0);
					jump.Play ();
					rb2d.AddForce (new Vector2 (0, playerJump));
				}
				if (velocity_y > 5) {
					velocity_y = 5;
				}
			}

			//accelerometer
			if(CT==ControlType.Accelerometer) {
				move = new Vector2 (Input.acceleration.x, Input.acceleration.x);
				if (move != Vector2.zero) {
					anim.SetBool ("isMoving", true);
					anim.SetFloat("vel_x", move.x);
					anim.SetFloat ("vel_y", rb2d.velocity.y);
				} else {
					anim.SetBool ("isMoving", false);
				}
				rb2d.velocity = new Vector2 (move.x * playerSpeed*4, rb2d.velocity.y);

				float velocity_y = rb2d.velocity.y;
				if (grounded && velocity_y <= 0) {
					rb2d.velocity = new Vector2 (0, 0);
					jump.Play ();
					rb2d.AddForce (new Vector2 (0, playerJump));
				}
				if (velocity_y > 5) {
					velocity_y = 5;
				}
			}

			//touch
			if(CT==ControlType.Touch) {
				move = new Vector2 (touchControl.InputDirection.x, touchControl.InputDirection.x);
				if (move != Vector2.zero) {
					anim.SetBool ("isMoving", true);
					anim.SetFloat("vel_x", move.x);
					anim.SetFloat ("vel_y", rb2d.velocity.y);
				} else {
					anim.SetBool ("isMoving", false);
				}
				rb2d.velocity = new Vector2 (move.x * playerSpeed, rb2d.velocity.y);

				float velocity_y = rb2d.velocity.y;
				if (grounded && velocity_y <= 0) {
					rb2d.velocity = new Vector2 (0, 0);
					jump.Play ();
					rb2d.AddForce (new Vector2 (0, playerJump));
				}
				if (velocity_y > 5) {
					velocity_y = 5;
				}
			}

		}

		if (gameManager.gameState==GameManager.GameState.GamePause) {
		}

		if (gameManager.gameState==GameManager.GameState.GameOver) {
			if (!saveCoinOnce) {
				PlayerPrefs.SetInt ("Coin", scoreManager.CurrentCoin);
				saveCoinOnce = true;
			}
		}

		//for warpping
		if(transform.position.x<=-1.73f)	{
			transform.position = new Vector3 (Camera.transform.position.x+1.73f,transform.position.y,transform.position.z);
		} else if(transform.position.x>=1.73f) {
			transform.position = new Vector3 (Camera.transform.position.x-1.73f,transform.position.y,transform.position.z);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Spring") {
			if (Score.instance.isJumping == false) {
				Score.instance.isJumping = true;
			}
			if (gameManager.gameState == GameManager.GameState.GamePlay)
			Spring_FX.Play ();
			StartCoroutine ("particleJump");
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.AddForce (new Vector2 (0, 1100f));

		}
		if (col.tag == "EndTrigger") {
			gameManager.gameState = GameManager.GameState.GameOver;
		}

		if (col.tag == "Collectable") {
			if (col.name == "Apple"&&rb2d.velocity.y<=0) {
				Spring_FX.Play ();
				camera.ShakeCamera (0.02f,0.5f);
				StartCoroutine ("particleJump");
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, 450f));
			}

			if (col.name == "Cherry"&&rb2d.velocity.y<=0) {
				Spring_FX.Play ();
				camera.ShakeCamera (0.05f,0.5f);
				StartCoroutine ("particleJump");
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, 700f));
			}

			if (col.name == "Grape"&&rb2d.velocity.y<=0) {
				Spring_FX.Play ();
				camera.ShakeCamera (0.1f,1);
				StartCoroutine ("particleJump");
				rb2d.velocity = new Vector2 (0, 0);
				rb2d.AddForce (new Vector2 (0, 1000f));
			}
			//coinsss
			if (col.name=="Gold") {
				scoreManager.CurrentCoin += 2;
			}
			if (col.name=="Silver") {
				scoreManager.CurrentCoin ++;
			}
		}
		
	}

	IEnumerator particleJump () {
		JumpParticle.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		JumpParticle.SetActive (false);

	}
}
