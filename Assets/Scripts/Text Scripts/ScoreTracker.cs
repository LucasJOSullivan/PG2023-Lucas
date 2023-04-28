using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    //EndCard endReport;
    OldTargetHealth tracker;
    public int score;
    TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //endReport = FindObjectOfType<EndCard>();
        scoreText = GetComponent<TMP_Text>();
        score = 0;
        displayScore();
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
        displayScore();
    }

    internal void displayScore()
    {
        scoreText.text = "Score: " + score;
    }

    internal void hideScore()
    {
        scoreText.text = "";
    }
}
