using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF_Weapon_Control : MonoBehaviour, IShoot

{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;

    int burst_count, burst_limit;
    bool trigger_held;
    float reburst_delay, refire_delay;
    public Transform spawnpoint, bulletCloneTemplate;

    public void triggerHeld()
    {
        trigger_held = true;
        if ((refire_delay <= 0.0f) && (burst_count < burst_limit))
        {
            Instantiate(bulletCloneTemplate, spawnpoint.position, spawnpoint.rotation);
            audioSource.PlayOneShot(audioClip, volume);
            burst_count += 1;
            refire_delay = 0.076923076923f;
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
        burst_limit = 3;
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
