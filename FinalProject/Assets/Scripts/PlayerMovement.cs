using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float ForwardSpeed;
    public float SidewaysSpeed;
    public float JumpForce;

    private bool isOnGround;
    private bool moveLeft;
    private bool moveRight;
    private bool moveJump;

    // Start is called before the first frame update
    void Start() {
        isOnGround = true;
        moveLeft = false;
        moveRight = false;
        moveJump = false;
    }

    private void Update(){
        checkInput();
    }

    void FixedUpdate() {
        MoveForward();

        if (moveLeft)
            LeftMovement();
        if (moveRight)
            RightMovement();
        if (moveJump)
            JumpMovement();
    }

    private void MoveForward() {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 1 * ForwardSpeed * Time.deltaTime);
    }

    private void RightMovement() {
        rb.AddForce(SidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void LeftMovement() {
        rb.AddForce(-SidewaysSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void JumpMovement() {
        if (isOnGround){
            rb.AddForce(0, JumpForce, 0);
            isOnGround = false;
        }
    }

    private void checkInput() {
        checkInput_Left();
        checkInput_Right();
        checkInput_Jump();
    }

    private void checkInput_Left() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveLeft = true;
        else
            moveLeft = false;
    }

    private void checkInput_Right() {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveRight = true;
        else
            moveRight = false;
    }

    private void checkInput_Jump() {
        if (Input.GetKey(KeyCode.Space))
            moveJump = true;
        else
            moveJump = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }

    public void StopMovements() {
        FindObjectOfType<PlayerMovement>().enabled = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
