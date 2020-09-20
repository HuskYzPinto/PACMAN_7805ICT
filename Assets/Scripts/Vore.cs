using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Vore : MonoBehaviour
{
    public int totalDots = 328;
    public float totalscore;
    public int count;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    { 
        count = 0;
        totalscore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count >= totalDots && !done){
            print("GAME DONE");
            GameObject timer = GameObject.Find("Timer");
            Timer time = timer.GetComponent<Timer>();
            totalscore = (totalDots/(time.totalTime) * 100);
            if (!done){
                SceneManager.LoadScene("Victory", LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Victory"));
                done = true;
            }
        }
    }
}


