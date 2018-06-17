using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapByBoundary : MonoBehaviour {
  void OnTriggerExit(Collider other) {
    Wrap(other.gameObject.GetComponent<Rigidbody>());
  }

  private void Wrap(Rigidbody body) {
    float x = body.position.x;
    float z = body.position.z;

    if (x > transform.localScale.x / 2) {
      x -= transform.localScale.x;
    }

    if (x < -transform.localScale.x / 2) {
      x += transform.localScale.x;
    }

    if (z > transform.localScale.z / 2) {
      z -= transform.localScale.z;
    }

    if (z < -transform.localScale.z / 2) {
      z += transform.localScale.z;
    }

    body.position = new Vector3(x, 0, z);
  }
}
