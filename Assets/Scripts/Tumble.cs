using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumble : MonoBehaviour {
  public float tumble;

  public float minScale = 1.0f;
  public float maxScale = 10.0f;

  public float minSpeed = 1.0f;
  public float maxSpeed = 10.0f;

  void Start() {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.angularVelocity = Random.insideUnitSphere * Random.Range(0, tumble);
  }
}
