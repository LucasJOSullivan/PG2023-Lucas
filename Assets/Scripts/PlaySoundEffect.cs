using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource.Play();
        audioSource.PlayOneShot(clip, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
