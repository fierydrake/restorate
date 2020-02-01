using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {


    public Rigidbody2D player1;
    public Rigidbody2D player2;

    public Text winText;

    private SoundManager sound;

    void Start() {
        winText.gameObject.SetActive(false);
        sound = Camera.main.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if ( col.gameObject == player1.gameObject || col.gameObject == player2.gameObject ) {
            sound.OnExitLevel();
            winText.gameObject.SetActive(true);
            Destroy(player1.gameObject);
            Destroy(player2.gameObject);
        }
    }
}
