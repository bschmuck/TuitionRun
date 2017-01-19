using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public float Score = 0;

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
		UIManager.Instance.UpdateScoreLabel (Score);
	}

	public void IncreaseScore(float value) {
		Score += value;
		UIManager.Instance.UpdateScoreLabel (Score);
	}


}