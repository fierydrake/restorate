using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour {

    public bool movementFixed;
    public bool stutterFixed;
    public Rigidbody2D rb;

    public Collider2D floorCollider;

    public string leftKey;
    public string rightKey;

    float thrust = 50.0f;
    float maxVelocity = 5.0f;

    private bool moveLeft;
    private bool moveRight;
    private bool releaseLeft;
    private bool releaseRight;
    private bool holdingKey = false;
    private bool isGrounded = false;

    void Start() {
         
    }

    // Update is called once per frame
    void Update() {
        setMoveVars();
    }

    void FixedUpdate() {
        move();
    }


    void move() {
        // If movement is not fixed invert movement
        int fixMod = movementFixed ? 1 : -1;
        bool brake = (releaseLeft || releaseRight || !Input.anyKey) && isGrounded;

        if (checkStutter() && (moveRight || moveLeft) && !brake) {
            var thrustMod = moveRight ?  1 : -1;
            if (rb.velocity.magnitude < maxVelocity) {
                rb.AddForce(transform.right * thrust * thrustMod * fixMod);
            }
            moveRight = false;
            moveLeft = false;
            holdingKey = true;
        }

        if (brake) {
            rb.velocity = Vector3.zero;
        }
        
    }

    bool checkStutter() {
        return (stutterFixed || !holdingKey);
    }

    void setMoveVars() {
        moveRight = Input.GetKey(rightKey);
        moveLeft = Input.GetKey(leftKey);
        releaseRight = Input.GetKeyUp(rightKey);
        releaseLeft = Input.GetKeyUp(leftKey);

        if (releaseRight || releaseLeft) {
            holdingKey = false;
        }
    }

    void OnTriggerEnter2D() {
        Debug.Log("ON FLOOR");
        isGrounded = true;
    }
    void OnTriggerExit2D(){
        Debug.Log("LEAVING FLOOR");
        isGrounded = false;
    }

}
