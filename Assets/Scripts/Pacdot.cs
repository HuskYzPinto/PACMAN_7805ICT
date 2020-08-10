using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Mouth")
        {
            Destroy(gameObject);
            GameObject score = GameObject.Find("Score");
            Vore currentScore = score.GetComponent<Vore>();
            currentScore.count += 1;
        }
    }
}
