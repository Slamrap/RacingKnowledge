using KartGame.KartSystems;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    //public PlayerMovement PlayerMoveScript;
    public Rigidbody Player_rb;
    public ArcadeKart script1;

    public GameObject confettiPrefab;

    // New size for the glass pane when collided
    private Vector3 newScale = new Vector3(3.7f, 3.7f, 0.5f);
    private bool Collided_flag = false;
    private bool correct_flag = false;

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Obstacle") {
            //Debug.Log("Hit Obstacle!");
            stop();
            Collided_flag = true;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collision.collider.tag == "Glass") {
            //Debug.Log("Hit Glass!");
            stop();
            Collided_flag = true;
            FindObjectOfType<GameManager>().GameOver();
        }
        if (collision.collider.tag == "Ground") {
            //Debug.Log("Ground");
            correct_flag = false;
        } 
    }

    // Collided with Correct Answer Panel
    private void OnTriggerEnter(Collider other) {
        if (!Collided_flag && other.tag == "Glass_CorrectAnswer" && !correct_flag) {
            correct_flag = true;
            FindObjectOfType<GameManager>().GetNextQuestion();
            FindObjectOfType<GameManager>().IncreaseScore();

            Vector3 glassPos = other.transform.position;
            Vector3 newPos = new Vector3(glassPos.x, glassPos.y + 0.5f, glassPos.z + 8f);
            GameObject particles = (GameObject)Instantiate(confettiPrefab, glassPos, Quaternion.identity);
            particles.GetComponent<ParticleSystem>().Play();
        }
        if (other.tag == "EndCollider") {
            //Debug.Log("EndCollider");
            stop();
        }
        if (other.tag == "Obstacle") {
            //Debug.Log("Hit Water!");
            stop();
            Collided_flag = true;
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void stop() {
        Player_rb.constraints = RigidbodyConstraints.None;
        Player_rb.drag = 3;
    }

}
