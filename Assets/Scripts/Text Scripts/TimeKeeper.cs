using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour

{
    ScoreTracker scoreHide;
    EndCard endReport;
    Player_Control player;
    float maxTime = 10;
    float currentTime;
    bool timerStopped;


    TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        scoreHide = FindObjectOfType<ScoreTracker>();
        player = FindObjectOfType<Player_Control>();

        endReport = FindObjectOfType<EndCard>();
        timeText = GetComponent<TMP_Text>();
        timeText.text= "Time Remaining: " + maxTime.ToString("0.00") + "s";
        startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStopped == false)
        {
            currentTime -= Time.deltaTime;
        }

        timeText.text = "Time Remaining: " + currentTime.ToString("0.00") + "s";
        if (currentTime <= 0)
        {
            currentTime = 0;
            stopTimer();
            endReport.showEndCard();
            //Player_Control.DisableControl;
        }
        
    }

    internal void startTimer()
    {
        currentTime = maxTime;
        timerStopped = false;
    }

    internal void stopTimer()
    {
        timerStopped = true;
        timeText.text = "";
        scoreHide.hideScore();
        player.disablePlayerControl();
    }
}
