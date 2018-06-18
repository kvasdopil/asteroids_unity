using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject asteroid;
	public Vector3 spawnValues;

	void Start() {
		SpawnWaves();
	}

	private void SpawnWaves() {
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject oid = Instantiate(asteroid, spawnPosition, spawnRotation) as GameObject;
		// oid.GetComponent<Rigidbody>().AddForce(Vector3(0, 0, -1));
	}
}
