using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody2D rb;
    public Collider2D oc;
    private bool doJump = false;
    private bool canJump = true;
    public bool fixJump = true;
    public float randomJumpAngleRange = 45;
    public string jump;

    
    void Start()
    {

    }

    void Update() {
        if (Input.GetKeyDown(jump)) {
            doJump = true;
        }
    } 

    void FixedUpdate()
    {
        if (doJump & canJump) {
            if (fixJump) {
                rb.AddForce(transform.up * thrust);
            } else {
                // Debug.DrawLine(transform.position, transform.position + 5 * randomDownVector);
                rb.AddForce(-vectorCalc() * thrust);
            }
        }
    }

    void OnTriggerEnter2D() {
        doJump = false;
        canJump = true;
    }

    void OnTriggerExit2D(){
        canJump = false;
    }

    Vector3 vectorCalc(){
        var down = Vector3.down;
        var randomOffset = Random.Range(-randomJumpAngleRange, randomJumpAngleRange);
        return Quaternion.AngleAxis(randomOffset, Vector3.forward) * down;
    }
}
