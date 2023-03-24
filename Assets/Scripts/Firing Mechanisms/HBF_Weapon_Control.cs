using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBF_Weapon_Control : MonoBehaviour, IShoot
{
    public AudioSource audioSource;
    public AudioClip muzzleReport;
    public float audioVolume = 0.5f;

    enum gunState {Idle, Firing, Delayed}
    gunState currently = gunState.Idle;

    //int burst_count_to_min;
    int burst_count_to_max;
    public int roundsPerBurst;
    public float roundsPerSecond, burstsPerSecond; 
    float refire_delay, reburst_delay;
    bool trigger_held, trigger_locked;
    public bool automaticallyFireBursts;
    public Transform spawnPoint, bulletCloneTemplate;

        public void triggerPressed()
    {
        if ((automaticallyFireBursts == false) && (trigger_locked = false))
        {
            trigger_held = true;
        }

        /*
        while (burst_count_to_max < maxRoundsPerBurst)
        {
            trigger_held = true;
            trigger_locked = true;
            while (trigger_held == true)
            {
                Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
                audioSource.PlayOneShot(muzzleReport, audioVolume);
                refire_delay = (1 / roundsPerSecond);
                burst_count_to_max += 1;                
            }
            reburst_delay = (1 / burstsPerSecond);
            trigger_held = false;
        }

        if (reburst_delay == 0.0f)
        {
            trigger_locked = false;
            burst_count_to_max = 0;
        }
        */
    }

    
    public void triggerHeld()
    {
         //&& (currently != gunState.Firing)
        if ((automaticallyFireBursts == true) && (trigger_locked == false))
        {
            trigger_held = true;
        }
        /*
        if ((automaticallyFireBursts == true) && (trigger_locked == false))
        {
            triggerPressed();
        }
        */
    }

    public void triggerReleased()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //trigger_locked = false;
        refire_delay = 0.0f;
        reburst_delay = 0.0f;
        burst_count_to_max = 0;
    }

    // Update is called once per frame
    void Update()
    {
        refire_delay -= Time.deltaTime;
        reburst_delay -= Time.deltaTime;
        switch (currently)
        {
            case gunState.Idle:
                trigger_locked = false;
                if (trigger_held == true)
                {
                    burst_count_to_max = roundsPerBurst;
                    currently = gunState.Firing;
                }
                break;

            case gunState.Firing:
                if (burst_count_to_max != 0)
                {
                    trigger_locked = true; 
                    {
                        Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
                        audioSource.PlayOneShot(muzzleReport, audioVolume);
                        burst_count_to_max -= 1;
                        refire_delay = (1 / roundsPerSecond);
                    }
                }
                else
                {
                    currently = gunState.Delayed;
                }

                break;

            case gunState.Delayed:
                reburst_delay = (1 / burstsPerSecond);
                if (reburst_delay <= 0.0f)
                {
                    currently = gunState.Idle;
                }
                break;
        }
        //refire_delay -= Time.deltaTime;
        //reburst_delay -= Time.deltaTime;
        /*
        if (trigger_held == false)
        {

        }

        if (burst_count_to_max == burst_limit)
        {
            reburst_delay = 0.285714285714f;
        }
        
        reburst_delay -= Time.deltaTime;
        */

        /*
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
            }
        */
    }
}
