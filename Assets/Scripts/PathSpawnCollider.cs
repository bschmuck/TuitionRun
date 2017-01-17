using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawnCollider : MonoBehaviour {

	public GameObject Path;
	public Transform[] PathSpawnPoints;

	void Start () {
	}


	void OnTriggerEnter(Collider hit) {
		print ("Hit!");
		Instantiate (Path, PathSpawnPoints [0].position, PathSpawnPoints [0].rotation);
	}
}
