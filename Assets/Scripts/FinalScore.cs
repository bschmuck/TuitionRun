using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text ScoreLabel;

	// Use this for initialization
	void Start () {
		float score = ScoreManager.Instance.Score;
		if (score < 52732) {
			ScoreLabel.text = "You only paid $" + score + ". Subra is sad. :-(";
		} else {
			ScoreLabel.text = "You paid $" + score + ". You have successfully supported the bureaucracy!!!";
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
