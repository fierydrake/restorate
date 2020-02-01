using System.Collections;
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

    // Stutter stats
    public float minStutterPercent = 0.5f;
    public float groundThrust = 120.0f;
    float airThrust = 45.0f;

    // Max speed
    public float maxVelocity = 4.0f;

    private bool moveLeft;
    private bool moveRight;
    private bool releaseLeft;
    private bool releaseRight;
    private bool holdingKey = false;
    private SoundManager soundManager;
    private bool fixedMoveSoundOn = false;
    private int playerNumber;


    void Start() {
        soundManager = Camera.main.GetComponent<SoundManager>();
        playerNumber = GetComponent<PlayerNumber>().playerNumber;
    }

    // Update is called once per frame
    void Update() {
        setMoveVars();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-maxVelocity, maxVelocity), rb.velocity.y);
        if (Math.Abs(rb.velocity.x) > 0.0f) {
            if (!fixedMoveSoundOn && grounding.grounded) {
                fixedMoveSoundOn = true;
                Debug.Log("turning sound ONNNNN");
                soundManager.OnWorkingMovementStart(playerNumber);
            }
            if (!grounding.grounded){
                soundManager.OnWorkingMovementStop(playerNumber);
                fixedMoveSoundOn = false;
                Debug.Log("Flying off");
            }
        } else {
            if (fixedMoveSoundOn || !grounding.grounded) {
                fixedMoveSoundOn = false;
                soundManager.OnWorkingMovementStop(playerNumber);
                Debug.Log("Stopped off");
            }
        }
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
            rb.AddForce(transform.right * thrust * thrustMod * fixMod * UnityEngine.Random.Range(minStutterPercent, 1.0f));
            holdingKey = true;
        }
        moveRight = false;
        moveLeft = false;
        if (brake) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void changeDirection() {
        // -1 is left, 1 is right
        int invertBroken = movementFixed ? 1 : -1;

        int newDirection = moveRight ? 1 : -1;
        int travellingDirection = rb.velocity.x >= 0 ? 1*invertBroken : -1*invertBroken;

        if (newDirection != travellingDirection) {
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
