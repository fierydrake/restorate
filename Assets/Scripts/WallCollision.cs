using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallCollision : MonoBehaviour
{
    public string groundTag;
    public string wallTag;
    public string personTag;
    private int playerNumber;
    private SoundManager soundManager;

    void Start() {
        soundManager = Camera.main.GetComponent<SoundManager>();
        playerNumber = GetComponent<PlayerNumber>().playerNumber;
    }

    void OnCollisionEnter2D(Collider2D other) {
    if (other.tag == groundTag || other.tag == wallTag || other.tag == personTag){
            soundManager.OnImpact(playerNumber);
        }
    }
}
