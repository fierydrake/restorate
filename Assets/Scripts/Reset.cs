using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {


    public string resetKey = "space";
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public float startX = 0.0f;
    public float startY = 0.0f;
    private Rigidbody2D player1;
    private Rigidbody2D player2;

    private bool resetPressed;
    // Start is called before the first frame update
    void Start() {
        player1 = GameObject.FindWithTag(player1Tag).GetComponent<Rigidbody2D> ();
        player2 = GameObject.FindWithTag(player2Tag).GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update() {
        resetPressed = Input.GetKey(resetKey);
    }

    void FixedUpdate() {
        if (resetPressed) {
            resetPressed = false;
            player1.position = new Vector3 (startX,
                                      startY,
                                      0.0f );
            player2.position = new Vector3 (startX,
                                      startY,
                                      0.0f );
        }
    }
}
