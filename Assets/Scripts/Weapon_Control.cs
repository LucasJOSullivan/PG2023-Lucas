using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Control : MonoBehaviour, IShoot
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;

    int burst_count;
    public int burstLimit;
    public int roundsPerSecond, burstsPerSecond;
    float reburst_delay, refire_delay;
    bool trigger_held;
    public bool useBurstLimit;
    public Transform spawnpoint, bulletCloneTemplate;

    public void triggerHeld()
    {
        trigger_held = true;
        if ((refire_delay <= 0.0f) && (burst_count < burstLimit))
        {
            Instantiate(bulletCloneTemplate, spawnpoint.position, spawnpoint.rotation);
            audioSource.PlayOneShot(audioClip, volume);
            if (useBurstLimit = true)
            {
                burst_count += 1;
            }
            refire_delay = (roundsPerSecond / 1000);
            reburst_delay = (burstsPerSecond / 1000);
        }
    }

    public void triggerReleased()
    {
        trigger_held = false;
    }

    public void triggerPressed()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        trigger_held = false;
        //burst_limit = 3;
        burst_count = 0;
        reburst_delay = 0.0f;
        refire_delay = 0.0f;
    }

    // Update is called once per frame
    void Update()

    {
        refire_delay -= Time.deltaTime;
        if (trigger_held == false)
        {
            burst_count = 0;
        }
        /*
        if (burst_count == burst_limit)
        {
            reburst_delay = 0.285714285714f;
        }
        
        reburst_delay -= Time.deltaTime;
        */

        /*
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletCloneTemplate, spawnpoint.position, spawnpoint.rotation);
            }
        */
    }
}
