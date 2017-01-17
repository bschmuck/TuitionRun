using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

	AudioSource source;
	float time;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 1);
		time += Time.deltaTime;
		if (time >= .1) {
			ScoreManager.Instance.IncreaseScore(1f);
			time = 0;
		}

	}

	void OnTriggerEnter(Collider collision) {
		print (collision.gameObject.tag);
		if (collision.gameObject.tag == "Player") {
			ScoreManager.Instance.IncreaseScore(100f);
			source.Play ();
			print ("Collected!");
			Destroy (gameObject);
		}
	}
}
