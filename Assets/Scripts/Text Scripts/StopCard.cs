using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StopCard : MonoBehaviour
{
    ScoreTracker scoreReport;
    int endScore;
    TMP_Text cardText;
    // Start is called before the first frame update
    void Start()
    {
        scoreReport = FindObjectOfType<ScoreTracker>();
        cardText = GetComponent<TMP_Text>();
        cardText.text = "Destroy targets to score as many points as possible before time runs out. \n\nHit the 'space' key to begin the game.";
    }

    internal void hideStopCard()
    {
        cardText.text = "";
    }

    internal void showStopCard()
    {
        cardText.text = "Game Over \n\nYour score is: " + scoreReport.score;
    }
}
