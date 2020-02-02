using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("splashscreen", LoadSceneMode.Single);
        // Debug.Log("splash loaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("enter")||Input.GetKeyUp("return")){
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            Debug.Log("enter pressed");
            SceneManager.LoadScene("main", LoadSceneMode.Single);
            Debug.Log("main loaded");
        }
    }
}
