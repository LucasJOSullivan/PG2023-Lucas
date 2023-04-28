using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour

{
    ScoreTracker scoreToggle;
    StopCard endReport;
    Player_Control player;
    float maxTime = 30;
    float currentTime;
    bool timerStopped;
    TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
        endReport = FindObjectOfType<StopCard>();
        scoreToggle = FindObjectOfType<ScoreTracker>();
        player = FindObjectOfType<Player_Control>();
        currentTime = maxTime;
        timerStopped = true;
        timeText.text= "";
        scoreToggle.hideScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStopped == false)
        {
            currentTime -= Time.deltaTime;
            timeText.text = "Time Remaining: " + currentTime.ToString("0.00") + "s";
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            stopTimer();
            endReport.showStopCard();
            //Player_Control.DisableControl;
        }
        
    }

    internal void hideTimer()
    {
        timeText.text = "";
    }

    internal void startTimer()
    {
        timeText.text = "Time Remaining: " + currentTime.ToString("0.00") + "s";
        timerStopped = false;
        scoreToggle.displayScore();
    }

    internal void stopTimer()
    {
        timerStopped = true;
        player.disablePlayerControl();
        timeText.text = "";
        scoreToggle.hideScore();
    }
}
