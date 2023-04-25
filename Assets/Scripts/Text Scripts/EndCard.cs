using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndCard : MonoBehaviour
{
    ScoreTracker scoreReport;
    TMP_Text cardText;
    // Start is called before the first frame update
    void Start()
    {
        //scoreReport.
        cardText = GetComponent<TMP_Text>();
        cardText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void showEndCard()
    {
        scoreReport.getScore();
        cardText.text = "Game Over \n\nYour score is: " + scoreReport.score;
    }
}
