using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectGround : MonoBehaviour {

	void OnTriggerEnter() {
		print ("Grounded!");
		CharacterState.Instance.isGrounded = true;
	}

	void OnTriggerStay() {
		CharacterState.Instance.isGrounded = true;
	}

	void OnTriggerExit() {
		print ("Not Grounded!");
		CharacterState.Instance.isGrounded = false;
	}
}
