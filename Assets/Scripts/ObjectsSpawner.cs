using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

	public Transform[] SpawnPoints;
	public GameObject[] Bonus;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < SpawnPoints.Length; i++) {
			bool placeItem = Random.Range (0, 6) == 0;
			if (placeItem) {
				int bonusIndex = Random.Range (0, Bonus.Length);
				CreateObject(SpawnPoints[i].position, Bonus[bonusIndex], bonusIndex == 1);
			}
		}
	}

	void CreateObject(Vector3 position, GameObject prefab, bool shouldRotate) {
		if(shouldRotate) {
			Instantiate (prefab, position, Quaternion.Euler(90, 0, 0));
		} else {
			Instantiate (prefab, position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
