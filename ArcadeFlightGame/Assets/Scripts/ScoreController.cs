using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {
    [SerializeField] private GameObject playerObject;
    private int score;

    [SerializeField] private TextMeshProUGUI scoreText;

    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("PlayerShip");
        pc = playerObject.GetComponent<PlayerController>();
        score = pc.score;
    }

    // Update is called once per frame
    void Update()
    {
        score = pc.score;
        //Debug.Log("Score: " + score);

        scoreText.text = score.ToString();
    }
}
