using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 1);

	}

	void OnTriggerEnter(Collider collision) {
		print (collision.gameObject.tag);
		if (collision.gameObject.tag == "Player") {
			if (gameObject.tag == "Natty") {
				CharacterMovement.Instance.SpeedBoost ();
			}
			ScoreManager.Instance.IncreaseScore(100f);
			source.Play ();
			print ("Collected!");
			Destroy (gameObject);
		}
	}
}
