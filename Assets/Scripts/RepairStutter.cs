using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairStutter : MonoBehaviour
{
    private SoundManager sound;

    private List<GameObject> fixedPlayers;

    void Start() {
        fixedPlayers = new List<GameObject>();
        sound = Camera.main.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<Movement>().stutterFixed = true;
            if (!fixedPlayers.Contains(other.gameObject)) {
                fixedPlayers.Add(other.gameObject);
                sound.OnRepair();
            }
        }
    }
}
