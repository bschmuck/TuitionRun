using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text PowerupText;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			DestroyImmediate(this);
		}
	}

	//singleton implementation
	private static UIManager instance;
	public static UIManager Instance {
		get {
			if (instance == null) {
				instance = new UIManager ();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		PowerupText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowPowerUp() {
		PowerupText.enabled = true;
	}

	public void HidePowerUp() {
		PowerupText.enabled = false;
	}
}
