using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {
    //[SerializeField] private GameObject playerObject;
    private int score;

    [SerializeField] private TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
        //Debug.Log("Score: " + score);

        scoreText.text = score.ToString();
    }
}
