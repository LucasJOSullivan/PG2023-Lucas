using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    TargetHealth tracker;
    int score = 0;
    TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame   

    /*
    void Update()
    {       
        if (tracker.health <= 0)
        {
            addScore();
        }
    }
    */



    internal void addScore()
    {
        score += 5;
        scoreText.text = "Score: " + score;
    }
}
