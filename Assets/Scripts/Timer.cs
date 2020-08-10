using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text output;
    public float totalTime;
    bool timerStarted;
    bool gameStarted;
    void Start(){
        gameStarted = false;
        timerStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (!gameStarted && Input.anyKey){
            gameStarted = true;
            timerStarted = true;
        }
        if (gameStarted){
            if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory"){
                timerStarted = false;
            }
            if (timerStarted){
                totalTime += Time.deltaTime;
            }
        }
    }
}
