using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
  	public float ttl = 1.0f;

	void Update() {
		if (Time.time > ttl) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		ttl = Time.time + ttl;
	}
}
