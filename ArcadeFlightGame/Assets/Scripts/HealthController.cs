﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Scene SceneToLoad;
    private int health;
    [HideInInspector] public float finalTime;

    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private GameObject heart4;
    private GameObject heart5;

    //private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");
        heart4 = GameObject.Find("Heart4");
        heart5 = GameObject.Find("Heart5");

        health = PlayerPrefs.GetInt("PlayerHealth");
    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerPrefs.GetInt("PlayerHealth");
        //Debug.Log("Health: " + health);

        if(health == 5) {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(true);
        }
        else if(health == 4) {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if(health == 3) {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if(health == 2) {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if(health == 1) {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if(health == 0) {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);

            //Death - Stop Time and Display Menu
            Time.timeScale = 0f;

            //__CHANGE__Show a menu w/ possible leaderboard
            SceneManager.LoadScene(SceneToLoad.handle);
        }
    }
}
