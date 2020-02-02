using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {


    public Rigidbody2D player1;
    public Rigidbody2D player2;

    public Text winText;

    private SoundManager sound;

    private bool isWin = false; 

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
            isWin = true;
        }
    }
    void Update(){

        if ((Input.GetKeyDown("enter") || Input.GetKeyDown("return")) && isWin){
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            Debug.Log("enter pressed");
            Application.LoadLevel(Application.loadedLevel);
            Debug.Log("main loaded");
        }
    }
}
