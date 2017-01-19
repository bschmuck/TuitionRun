using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public bool didUpdate = false;
	float secondsElapsed = 0;

	Quaternion originalRotation;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			DestroyImmediate(this);
		}
		DontDestroyOnLoad(transform.gameObject);
	}

	//singleton implementation
	private static CameraManager instance;
	public static CameraManager Instance {
		get {
			if (instance == null) {
				instance = new CameraManager ();
			}
			return instance;
		}
	}


	// Use this for initialization
	void Start () {
		originalRotation = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!didUpdate) {
			if (secondsElapsed <= 4.5) {
				secondsElapsed += Time.deltaTime;
				transform.RotateAround (transform.position, transform.up, 1.5f);
			} else {
				transform.rotation = originalRotation;
				didUpdate = true;
			}
		}
	}
}
