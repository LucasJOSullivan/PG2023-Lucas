using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndCard : MonoBehaviour
{
    TMP_Text cardText;
    // Start is called before the first frame update
    void Start()
    {
        cardText = GetComponent<TMP_Text>();
        cardText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
