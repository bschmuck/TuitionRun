using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunner : MonoBehaviour {

	private CharacterController controller;
	private Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (CameraManager.Instance.didUpdate) {
			anim = GetComponentInChildren<Animator> ();
			anim.SetBool (Constants.AnimationStarted, true);
		}
		
	}
}
