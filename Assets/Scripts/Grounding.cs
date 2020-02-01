﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounding : MonoBehaviour
{
    private int groundingCount = 0;

    public bool grounded {
        get { return groundingCount > 0; }
    }

    void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Ground"){
            groundingCount++;
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Ground"){
            groundingCount--;
        }
    }

}
