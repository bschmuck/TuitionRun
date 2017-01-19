using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public Text ScoreLabel;

	// Use this for initialization
	void Start () {
		ScoreLabel.text = "Your Score: " + ScoreManager.Instance.Score;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
