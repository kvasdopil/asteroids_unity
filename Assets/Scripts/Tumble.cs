using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumble : MonoBehaviour {
  public float tumble;

  void Start() {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.angularVelocity = Random.insideUnitSphere * Random.Range(0, tumble);
  }
}
