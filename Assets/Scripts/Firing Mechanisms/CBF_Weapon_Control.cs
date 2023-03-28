using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBF_Weapon_Control : MonoBehaviour, IShoot
{
    public AudioSource audioSource;
    public AudioClip muzzleReport, chargeReport;
    public float audioVolume = 0.5f;

    enum gunState {Idle, Charging, Firing}
    gunState currently = gunState.Idle;

    RecoilScript recoilControl;
    //int burst_count_to_min;
    int burst_count_to_max;
    public int maxRoundsPerBurst, roundsPerCharge;
    //public float  secondsToDrain, burstsPerSecond;
    public float secondsToRoundCharge, roundsPerSecond; 
    //float  drain_delay, reburst_delay;
    float charge_timer, refire_delay;
    //bool charge_locked;
    bool trigger_held, trigger_locked;
    //public bool honorMinRoundsPerBurst;
    public bool honorMaxRoundsPerBurst;
    public Transform spawnPoint, bulletCloneTemplate;

    public void triggerHeld()
    {
        trigger_held = true;

        //if (trigger_locked == false)
        //{
        //    charge = 0.0f;
        //    trigger_held = true;            
        //    charge += Time.deltaTime;
        //    if ((charge >= secondsToRoundCharge) && (burst_count_to_max < maxRoundsPerBurst))
        //    {
        //        audioSource.PlayOneShot(chargeReport, audioVolume);
        //        charge = 0.0f;
        //        burst_count_to_max += 1;
        //    }
        //}

    }

    public void triggerReleased()
    {
        //if (trigger_held == true)
        //{
        //    trigger_locked = true;
        //    if (burst_count_to_max > 0)
        //    {
        //        Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
        //        audioSource.PlayOneShot(muzzleReport, audioVolume);
        //        refire_delay = (1 / roundsPerSecond);
        //        burst_count_to_max -= 1;
        //    }
        //}
        trigger_held = false;
        //trigger_locked = false;
    }

    public void triggerPressed()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        recoilControl = GetComponent<RecoilScript>();
        recoilControl.setDefaults(transform.localPosition, transform.localRotation);
        trigger_locked = false;
        
    }

    // Update is called once per frame
    void Update()

    {



        switch(currently)
        {
            case gunState.Idle:

                if (trigger_held)
                {
                    charge_timer = 0;
                    burst_count_to_max = 0;
                    currently = gunState.Charging;
                }


                break;

            case gunState.Charging:

                if (!trigger_held)
                {
                    if (burst_count_to_max > 0)
                    {
                        if ((burst_count_to_max > maxRoundsPerBurst) && (honorMaxRoundsPerBurst == true))
                        {
                            burst_count_to_max = maxRoundsPerBurst;
                        }
                        charge_timer = 0;
                        currently = gunState.Firing;
                    }
                    else
                    {
                        currently = gunState.Idle;
                    }
                }
                else
                {
                    charge_timer += Time.deltaTime;
                    if ((charge_timer >= secondsToRoundCharge) && (burst_count_to_max < maxRoundsPerBurst))
                    {
                        audioSource.PlayOneShot(chargeReport, audioVolume);
                        charge_timer = 0.0f;
                        burst_count_to_max += roundsPerCharge;
                    }

                }

                break;


            case gunState.Firing:
                {
                    charge_timer -= Time.deltaTime;

                    if (charge_timer <= 0.0f)
                    {
                        recoilControl.startRecoil();
                        Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
                        audioSource.PlayOneShot(muzzleReport, audioVolume);
                        refire_delay = (1 / roundsPerSecond);
                        burst_count_to_max -= 1;
                        charge_timer = refire_delay;
                    }

                    if (burst_count_to_max == 0)
                    {
                        currently = gunState.Idle;
                    }

                }




                break;
        }
        if (trigger_held == true)
        {

        }
        else
        {

        }
        /*
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
