using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmission : MonoBehaviour
{
    float time_to_live;
    //public AudioSource source;
    //public AudioClip clip;
    //public float volume = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        time_to_live = 1.00f;
    }

    // Update is called once per frame
    void Update()
    {
        time_to_live -= Time.deltaTime;
        if (time_to_live <= 0.00f)
        {
            Destroy(gameObject);
        }
    }
}
