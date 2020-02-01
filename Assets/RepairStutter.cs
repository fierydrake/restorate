using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStutter : MonoBehaviour
{
    private SoundManager sound;

    void Start() {
        sound = Camera.main.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<Movement>().stutterFixed = true;
            sound.OnRepair();
        }
    }
}
