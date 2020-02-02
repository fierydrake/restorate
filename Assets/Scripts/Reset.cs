using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {


    public string resetKey = "space";
    public float startX = 0.0f;
    public float startY = 0.0f;
    public Rigidbody2D otherRigidbody;
    public Rigidbody2D selfRigidbody;

    private bool resetPressed;

    // Update is called once per frame
    void Update() {
        // resetPressed = Input.GetKey(resetKey);
    }

    void FixedUpdate() {
        if (resetPressed) {
            resetPressed = false;
            otherRigidbody.position = new Vector3 (startX,
                                      startY,
                                      0.0f );
            selfRigidbody.position = new Vector3 (startX,
                                      startY,
                                      0.0f );
        }
    }
}
