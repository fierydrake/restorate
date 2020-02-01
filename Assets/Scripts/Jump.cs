using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody2D rb;
    public Collider2D oc;
    private bool doJump = false;
    public bool fixJump = true;
    public float randomJumpAngleRange = 45;
    public string jump;
    public Grounding grounding;

    void Update() {
        if (Input.GetKeyDown(jump)) {
            doJump = true;
        }
    } 

    void FixedUpdate()
    {
        if (doJump & grounding.grounded) {
            if (fixJump) {
                rb.AddForce(transform.up * thrust);
            } else {
                // Debug.DrawLine(transform.position, transform.position + 5 * randomDownVector);
                rb.AddForce(-vectorCalc() * thrust);
            }
            
        }
        doJump = false;
    }

    Vector3 vectorCalc(){
        var down = Vector3.down;
        var randomOffset = Random.Range(-randomJumpAngleRange, randomJumpAngleRange);
        return Quaternion.AngleAxis(randomOffset, Vector3.forward) * down;
    }
}
