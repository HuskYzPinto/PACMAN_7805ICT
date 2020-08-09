using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text output;
    float startTime;
    float endTime;
    void Start(){
        startTime = Time.time;
        print ("Current Scene: " + SceneManager.GetActiveScene().name);
        
    }

    // Update is called once per frame
    void Update(){
        print ("Current Scene: " + SceneManager.GetActiveScene().name);
        print ("Current Time: " + Time.time);
        if (SceneManager.GetActiveScene().name == "GameOver"){
            endTime = Time.time;
            this.enabled = false;
        }
    }
}
