using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text ScoreText;
	private float Score = 0;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			DestroyImmediate(this);
		}
	}

	//singleton implementation
	private static ScoreManager instance;
	public static ScoreManager Instance {
		get {
			if (instance == null) {
				instance = new ScoreManager ();
			}
			return instance;
		}
	}

	public void ResetScore() {
		Score = 0;
		UpdateScoreLabel ();
	}

	public void IncreaseScore(float value) {
		Score += value;
		UpdateScoreLabel ();
	}

	private void UpdateScoreLabel() {
		ScoreText.text = "Raised for Tuiton $" + Score;
	}
}