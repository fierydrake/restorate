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

    void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == groundTag || collision.gameObject.tag == wallTag || collision.gameObject.tag == personTag){
            soundManager.OnImpact(playerNumber);
        }
    }
}
