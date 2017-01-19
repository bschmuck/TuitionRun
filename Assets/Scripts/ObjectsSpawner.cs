using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

	public Transform[] SpawnPoints;
	public GameObject[] Bonus;
	public GameObject[] Obstacles;
	public GameObject Hunt;
	public Transform HuntSpawn;

	bool placeHunt = true;
	static bool isInitial = true;

	// Use this for initialization
	void Start () {
		if (!isInitial) {
			for (int i = 0; i < SpawnPoints.Length; i++) {
				bool placeItem = Random.Range (0, 6) == 0;
				bool placeObstacle = false;
				if (placeItem) {
					int bonusIndex = Random.Range (0, Bonus.Length);
					CreateObject (SpawnPoints [i].position, Bonus [bonusIndex], bonusIndex == 1);
				} else {
					placeObstacle = Random.Range (0, 10) == 0;
					if (placeObstacle) {
						int objIndex = Random.Range (0, Obstacles.Length);
						Instantiate (Obstacles [objIndex], SpawnPoints [i].position + new Vector3 (0, -0.5f, 0), Quaternion.identity);
					}
				}
				if (placeObstacle && i >= 2) {
					placeHunt = false;
				}
			}
			if (placeHunt && Random.Range (0, 2) == 0) {
				Instantiate (Hunt, HuntSpawn.position, Quaternion.identity);
			}
		} else {
			isInitial = false;
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
