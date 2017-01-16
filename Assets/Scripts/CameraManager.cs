using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	bool didUpdate = true;
	float secondsElapsed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!didUpdate && secondsElapsed >= 3) {
			transform.RotateAround (transform.position, transform.up, 180f);
			didUpdate = true;
		}
		secondsElapsed += Time.deltaTime;
	}
}
