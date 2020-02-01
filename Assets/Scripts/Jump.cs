using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float thrust = 400.0f;
    public Rigidbody2D rb;
    private bool doJump = false;
    public bool fixJump = true;
    public float randomJumpAngleRange = 45;
    public string jump;
    public Grounding grounding;

    private SoundManager sound;
    private int playerNumber;

    void Start() {
        sound = Camera.main.GetComponent<SoundManager>();
        playerNumber = GetComponent<PlayerNumber>().playerNumber;
    }

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
                sound.OnWorkingJump(playerNumber);
            } else {
                // Debug.DrawLine(transform.position, transform.position + 5 * randomDownVector);
                rb.AddForce(-vectorCalc() * thrust);
                sound.OnBrokenJump(playerNumber);
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
