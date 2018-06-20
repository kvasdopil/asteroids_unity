using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
  public GameObject explosion;
  public GameObject playerExplosion;

  private GameController gameController;

  private void Start() {
    GameObject gameControllerObject = GameObject.FindWithTag("GameController");  
    if (gameControllerObject != null)
    {
      gameController = gameControllerObject.GetComponent<GameController>();
    }
  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Boundary") {
      return;
    }

    Instantiate(explosion, transform.position, transform.rotation);
    // FIXME: delete explosion upon end
    Rigidbody otherRb = other.GetComponent<Rigidbody>();
    if (other.tag == "Player") {
      Instantiate(playerExplosion, otherRb.position, otherRb.rotation);
      // FIXME: delete explosion upon end
      gameController.GameOver();
    }

    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}