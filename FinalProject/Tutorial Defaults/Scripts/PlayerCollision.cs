using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement PlayerMoveScript;
    public Rigidbody Player_rb;

    // New size for the glass pane when collided
    private Vector3 newScale = new Vector3(3.7f, 3.7f, 0.5f);
    private bool Collided_flag = false;

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Obstacle") {
            //Debug.Log("Hit Obstacle!");
            PlayerMoveScript.enabled = false;
            Player_rb.constraints = RigidbodyConstraints.None;
            Collided_flag = true;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collision.collider.tag == "Glass") {
            //Debug.Log("Hit Glass!");
            PlayerMoveScript.enabled = false;
            //collision.collider.transform.localScale = newScale; -->old

            Player_rb.constraints = RigidbodyConstraints.None;

            Collided_flag = true;

            //collision.collider.GetComponent<Rigidbody>().AddForce(0, 0, 30); this doesn't work
            FindObjectOfType<GameManager>().GameOver();

        }
    }

    // Collided with Correct Answer Panel
    private void OnTriggerEnter(Collider other) {
        if (!Collided_flag) {
            FindObjectOfType<GameManager>().GetNextQuestion();
            FindObjectOfType<GameManager>().IncreaseScore();
        }

    }

}
