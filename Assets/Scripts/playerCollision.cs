using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public string personTag;
    public int magnitude;
    private int playerNumber;
    public Rigidbody2D rb;
    // private SoundManager soundManager;

    void Start() {
        // soundManager = Camera.main.GetComponent<SoundManager>();
        // playerNumber = GetComponent<PlayerNumber>().playerNumber;
    }

    void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == personTag){
            // soundManager.OnImpact(playerNumber);
 
            var force = transform.position - collision.transform.position;
 
            force.Normalize();
            rb.AddForce(force * magnitude);
        }
    }
}
