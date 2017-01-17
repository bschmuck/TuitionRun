using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20f;
	private CharacterController controller;
	private Animator anim;

	public float JumpSpeed = 8.0f;
	public float Speed = 6.0f;

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
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(-Vector3.right * Speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(Vector3.right * Speed * Time.deltaTime);
		}

		controller.Move (moveDirection * Time.deltaTime);
	}
}
