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

	float time;

	float PlayerY;

	float xHighBound = -45;
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
		anim = GetComponentInChildren<Animator> ();
		anim.SetBool (Constants.AnimationStarted, true);
		minY = controller.transform.position.y;
	}

	public void SpeedBoost() {
		bonusTime = 3f;
		print ("Speed Boost!");
	}
	
	// Update is called once per frame
	void Update () {

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
			ScoreManager.Instance.IncreaseScore(scoreAdder);
			time = 0;
		}
			
		float xPos = controller.gameObject.transform.position.x;
		controller.Move (moveDirection * Time.deltaTime * multiplier);
		print (xPos);

//		if (Input.GetKey (KeyCode.UpArrow)) {
//			moveDirection.y = JumpSpeed;
//		} else if (controller,Transform.p > 0) {
//			moveDirection.y = -Gravity;
//		} else {
//			moveDirection.y = 0;
//		}

		if (Input.GetKey (KeyCode.LeftArrow) && xPos > xLowBound) {
			transform.Translate (-Vector3.right * Speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow) && xPos < xHighBound) {
			transform.Translate (Vector3.right * Speed * Time.deltaTime);
		}

//		PlayerY += Time.deltaTime * .06f * multiplier / 1.45f;
//		if (moveDirection.y - Gravity * Time.deltaTime >= PlayerY) {
//			
//		}

//		print ("Min Y: " + minY);
//		print ("moveDirection: " + (moveDirection.y - Gravity * Time.deltaTime));
//		if (minY - (moveDirection.y - Gravity * Time.deltaTime) > -1.5) {
//			moveDirection.y -= Gravity * Time.deltaTime;
//		}
//
		controller.Move (transform.up * Time.deltaTime * .06f * multiplier/1.45f);
	//	xHighBound -= Time.deltaTime * 0.025f * multiplier/.7f;
	//	xLowBound -= Time.deltaTime * 0.025f * multiplier/.7f;
	}
}
