using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunner : MonoBehaviour {

	private Animator anim;
	private Vector3 moveDirection = Vector3.zero;

	public float Speed = 6.0f;

	// Use this for initialization
	void Start () {
//		moveDirection = transform.forward;
//		moveDirection = transform.TransformDirection (moveDirection);
//		moveDirection *= Speed;
	}
	
	// Update is called once per frame
	void Update () {

		if (CameraManager.Instance.didUpdate) {
			anim = GetComponentInChildren<Animator> ();
			anim.SetBool (Constants.AnimationStarted, true);
//			controller.Move(moveDirection * Time.deltaTime);
		}
		
	}
}
