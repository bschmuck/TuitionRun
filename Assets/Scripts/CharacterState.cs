using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour {

	public bool isGrounded = true;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			DestroyImmediate(this);
		}
	}

	//singleton implementation
	private static CharacterState instance;
	public static CharacterState Instance {
		get {
			if (instance == null) {
				instance = new CharacterState ();
			}
			return instance;
		}
	}
}