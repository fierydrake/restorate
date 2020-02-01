using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {


    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public string winCanvasTag = "WinCanvas";

    private Rigidbody2D player1;
    private Rigidbody2D player2;

    private Text winText;

    void Start() {
        player1 = GameObject.FindWithTag(player1Tag).GetComponent<Rigidbody2D> ();
        player2 = GameObject.FindWithTag(player2Tag).GetComponent<Rigidbody2D> ();

        winText = GameObject.FindWithTag(winCanvasTag).GetComponent<Text> ();
        winText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col) {
        string tag = col.gameObject.tag;
        if ( tag == player1Tag || tag == player2Tag) {
            winText.gameObject.SetActive(true);
            Destroy(player1.gameObject);
            Destroy(player2.gameObject);
        }
    }
}
