﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour {

    public bool movementFixed;
    public bool stutterFixed = true;
    public Rigidbody2D rb;

    public Grounding grounding;

    public string leftKey;
    public string rightKey;

    float groundThrust = 40.0f;
    float airThrust = 15.0f;
    float maxVelocity = 5.0f;

    private bool moveLeft;
    private bool moveRight;
    private bool releaseLeft;
    private bool releaseRight;
    private bool holdingKey = false;

    void Start() {
        rb.drag = 0.1f;
    }

    // Update is called once per frame
    void Update() {
        setMoveVars();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-maxVelocity, maxVelocity), rb.velocity.y);
        move();
    }


    void move() {
        // If movement is not fixed invert movement
        int fixMod = movementFixed ? 1 : -1;
        float thrust = grounding.grounded ? groundThrust : airThrust;
        bool brake = (releaseLeft || releaseRight || !Input.anyKey) && grounding.grounded;

        if (checkStutter() && (moveRight || moveLeft) && !brake) {
            var thrustMod = moveRight ?  1 : -1;
            changeDirection();
            rb.AddForce(transform.right * thrust * thrustMod * fixMod);
            holdingKey = true;
        }
        moveRight = false;
        moveLeft = false;
        if (brake) {
            rb.velocity = Vector3.zero;
        }
    }

    void changeDirection() {
        string newDirection = moveRight? "right" : "left";
        string travellingDirection = rb.velocity.x > 0 ? "right" : "left";

        if (newDirection != travellingDirection) {
            Debug.Log("Chaning Direction");
            rb.velocity = new Vector2(0, rb.velocity.y);
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

}
