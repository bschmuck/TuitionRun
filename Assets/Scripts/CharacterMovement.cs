using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	public float Gravity = 20f;
	private CharacterController controller;
	private Animator anim;

	public float JumpSpeed = 20.0f;
	public float Speed = 6.0f;

	bool isJumping = false;
	int jumpCounter = 0;

	float time;

	float PlayerY;

	float xHighBound = -44.5f;
	float xLowBound = -48;

	float bonusTime = 0;

	float Counter = 0;

	float minY = 0;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			DestroyImmediate(this);
		}
	}

	//singleton implementation
	private static CharacterMovement instance;
	public static CharacterMovement Instance {
		get {
			if (instance == null) {
				instance = new CharacterMovement ();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		moveDirection = transform.forward;
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= Speed;
		controller = GetComponent<CharacterController> ();
		minY = controller.transform.position.y;
	}

	public void SpeedBoost() {
		bonusTime = 3f;
		print ("Speed Boost!");
	}
	
	// Update is called once per frame
	void Update () {

		if (CameraManager.Instance.didUpdate) {
			anim = GetComponentInChildren<Animator> ();
			anim.SetBool (Constants.AnimationStarted, true);
			float multiplier = 1.0f;
			if (bonusTime > 0) {
				multiplier = 3f;
				bonusTime -= Time.deltaTime;
				Counter++;
				if (Counter < 20) {
					UIManager.Instance.ShowPowerUp ();
				} else if (Counter < 40) {
					UIManager.Instance.HidePowerUp ();
				} else {
					Counter = 0;
				}
			} else {
				Counter = 0;
				UIManager.Instance.HidePowerUp ();
			}

			time += Time.deltaTime;
			float scoreAdder = 1f;
			if (time >= .1) {
				if (multiplier > 1) {
					scoreAdder = multiplier * 3;
				}
				ScoreManager.Instance.IncreaseScore (scoreAdder);
				time = 0;
			}
				
			float xPos = controller.gameObject.transform.position.x;
			print (xPos);
			controller.Move (moveDirection * Time.deltaTime * multiplier);

			if (Input.GetKey (KeyCode.UpArrow) && !isJumping) {
				moveDirection.y = JumpSpeed / multiplier;
				isJumping = true;
				anim.SetBool (Constants.AnimationJump, true);
			} else if (controller.transform.position.y > 0.811 && isJumping) {
				jumpCounter++;
				if (jumpCounter == 30) {
					moveDirection.y = -Gravity / multiplier;
					jumpCounter = 0;
				}
				anim.SetBool (Constants.AnimationJump, false);
			} else {
				isJumping = false;
				moveDirection.y = 0;
				controller.transform.position = new Vector3 (controller.transform.position.x, 0.811f, controller.transform.position.z);
				anim.SetBool (Constants.AnimationJump, false);
			}
				
			if (Input.GetKey (KeyCode.LeftArrow) && xPos > xLowBound) {
				transform.Translate (-Vector3.right * Speed * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.RightArrow) && xPos < xHighBound) {
				transform.Translate (Vector3.right * Speed * Time.deltaTime);
			}
		}
	}
}
