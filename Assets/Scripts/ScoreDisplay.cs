using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Victory"){
            GameObject score = GameObject.Find("Score");
            Vore currentScore = score.GetComponent<Vore>();
            text.text = "Total Score: " + currentScore.totalscore.ToString("0");
            this.enabled = false;
        }
    }
}
