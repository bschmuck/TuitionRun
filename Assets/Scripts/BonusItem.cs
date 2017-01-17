using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 1);
	}

//	void OnCollisionEnter(Collision collision) {
//		GetComponent<AudioSource> ().Play ();
//		Destroy (gameObject);
//	}
}
