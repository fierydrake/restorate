using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {


    public Rigidbody2D player1;
    public Rigidbody2D player2;

    public Text endText;
    public Text timerBox;

    private SoundManager sound;

    public float timeLeft = 10;
    private bool gameFinished = false;

    

    void Start() {
        endText.gameObject.SetActive(false);
        sound = Camera.main.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if ( col.gameObject == player1.gameObject) {
            gameOver("Player 1 Wins! \n Press Enter to play again");
        }
        if (col.gameObject == player2.gameObject){
            gameOver("Player 2 Wins! \n Press Enter to play again");
        }
    }
    void Update(){

        if ((Input.GetKeyDown("enter") || Input.GetKeyDown("return")) && gameFinished){
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            Debug.Log("enter pressed");
            SceneManager.LoadScene("splashscreen", LoadSceneMode.Single);
            Debug.Log("main loaded");
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft > 0 ){
            timerBox.text = timeLeft.ToString("0.00");
        }
        if(timeLeft < 0)
        {
            gameOver("You both Lose! \n Press Enter to try again");
        }
        
    }
    void gameOver(string finaltext){

        Destroy(player1.gameObject);
        Destroy(player2.gameObject);
        sound.OnExitLevel();
        gameFinished = true;

        endText.text = finaltext;
        endText.gameObject.SetActive(true);
    }
}
