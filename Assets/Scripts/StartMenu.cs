﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainGame"));
    }
}
