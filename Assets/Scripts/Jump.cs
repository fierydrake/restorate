using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    // Jump controls
    public float flux = 0.8f; // minMax range of the broken jump
    public float flat = 0.4f; // Max range of the broken jump
    public float thrust = 250.0f;
    public float randomJumpAngleRange = 55;

    // player
    public Rigidbody2D rb;
    public Grounding grounding;

    // user
    private bool doJump = false;
    public bool fixJump = false;
    public string jump;

    // sound reqs
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
                rb.AddForce(-vectorCalc() * thrust * Random.Range(flat, flux));
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
