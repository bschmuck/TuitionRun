using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	public float Gravity = 0;
	private CharacterController controller;
	private Animator anim;

	public float JumpSpeed = 8.0f;
	public float Speed = 6.0f;

	float xHighBound = -45;
	float xLowBound = -48;

	// Use this for initialization
	void Start () {
		moveDirection = transform.forward;
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= Speed;
		controller = GetComponent<CharacterController> ();
		anim = GetComponentInChildren<Animator> ();
		anim.SetBool (Constants.AnimationStarted, true);
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = controller.gameObject.transform.position.x;
		controller.Move (moveDirection * Time.deltaTime);
		print (xPos);

		if (Input.GetKey (KeyCode.LeftArrow) && xPos > xLowBound) {
			transform.Translate (-Vector3.right * Speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow) && xPos < xHighBound) {
			transform.Translate (Vector3.right * Speed * Time.deltaTime);
		}
		Gravity -= 9.81f * Time.deltaTime * 0.01f;
		if (controller.isGrounded) {
			Gravity = 0;
		}
		controller.Move (transform.up * Time.deltaTime * .06f);
		xHighBound -= Time.deltaTime * 0.025f;
		xLowBound -= Time.deltaTime * 0.025f;
	}
}
