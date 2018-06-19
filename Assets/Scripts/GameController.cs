using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject asteroid;
	public float spawnRadius = 20.0f;

	public float minAsteroidSpawnWait = 1.0f;
	public float maxAsteroidSpawnWait = 2.0f; 

	public float minAsteroidScale = 1.0f;
	public float maxAsteroidScale = 6.0f;

	public float minAsteroidSpeed = 3.0f;
	public float maxAsteroidSpeed = 10.0f;

	private bool gameOver = false; 
	 
	//public GUIText gameOverText;

	void Start() {
		// gameOverText.text = "";
		StartCoroutine(SpawnAsteroids());
	}

	void Update() {
		if (gameOver)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel (Application.loadedLevel); // FIXME: obsolete
            }
        }
	}

	private IEnumerator SpawnAsteroids() {
		while (!gameOver) {
			yield return new WaitForSeconds(Random.Range(minAsteroidSpawnWait, maxAsteroidSpawnWait));
			Vector3 spawnPosition = new Vector3 (Random.Range (-1.0f, 1.0f), 0.0f, Random.Range (-1.0f, 1.0f)).normalized * spawnRadius;

			Debug.Log(spawnPosition);

			Quaternion spawnRotation = Quaternion.identity;
        	GameObject oid = Instantiate(asteroid, spawnPosition, spawnRotation) as GameObject;

			Transform tf = oid.GetComponent<Transform>();
    		tf.localScale = new Vector3(1.0f, 1.0f, 1.0f) * Random.Range(minAsteroidScale, maxAsteroidScale);
    		oid.GetComponent<Rigidbody>().AddForce(spawnPosition * -1.0f * Random.Range(minAsteroidSpeed, maxAsteroidSpeed));
		}
	}

	public void GameOver() {
		//gameOverText.text = "Game over! Press R to restart.";
		gameOver = true;
	}
}
