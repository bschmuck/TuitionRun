using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour {

	public AudioClip saw;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().clip = saw;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, 1);

	}

	void OnTriggerEnter(Collider collision) {
		print (collision.gameObject.tag);
		if (collision.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(GetComponent<AudioSource> ().clip, transform.position);
			if (gameObject.tag == "Natty") {
				CharacterMovement.Instance.SpeedBoost ();
			}
			ScoreManager.Instance.IncreaseScore(100f);
			print ("Collected!");
			Destroy (gameObject);
		}
	}
}
