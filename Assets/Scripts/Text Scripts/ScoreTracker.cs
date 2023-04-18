using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    TMP_Text scoreText, subtext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        subtext.text = "1";
        scoreText.text = "Score: " + subtext;
    }
}
