using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScore;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Victory"){
            GameObject score = GameObject.Find("Score");
            Vore currentScore = score.GetComponent<Vore>();
            if (currentScore.totalscore > PlayerPrefs.GetFloat("HighScore", 0)){
                PlayerPrefs.SetFloat("Highscore", currentScore.totalscore);
            }
            text.text = "Total Score: " + currentScore.totalscore.ToString("0")+"Highscore: "+ highScore.text;
            this.enabled = false;
        }
    }
}
