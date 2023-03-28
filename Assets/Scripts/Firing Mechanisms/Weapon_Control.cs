using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Control : MonoBehaviour, IShoot
{
    public AudioSource audioSource;
    public AudioClip muzzleReport;
    public float audioVolume = 0.5f;
    RecoilScript recoilControl;

    //int burst_count_to_min;
    int burst_count_to_max;
    //public int minRoundsPerBurst;
    public int maxRoundsPerBurst;
    //public float burstsPerSecond;
    public float roundsPerSecond; 
    //float reburst_delay;
    float refire_delay;
    bool trigger_held;
    //public bool honorMinRoundsPerBurst;
    public bool honorMaxRoundsPerBurst;
    public Transform spawnPoint, bulletCloneTemplate;

    public void triggerHeld()
    {
        trigger_held = true;
        if ((refire_delay <= 0.0f) && (burst_count_to_max < maxRoundsPerBurst))
        //if ((refire_delay <= 0.0f) && (reburst_delay <= 0.0f))
        {
            recoilControl.startRecoil();
            Instantiate(bulletCloneTemplate, spawnPoint.position, spawnPoint.rotation);
            audioSource.PlayOneShot(muzzleReport, audioVolume);
            refire_delay = (1 / roundsPerSecond);

            /*
            if ((honorMinRoundsPerBurst == true && (burst_count_to_min < minRoundsPerBurst)))
            {
                triggerHeld();
                burst_count_to_min += 1;
            }
            */
            if (honorMaxRoundsPerBurst == true)
            {
                burst_count_to_max += 1;
                //reburst_delay = (1 / burstsPerSecond + refire_delay);
            }


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
        recoilControl = GetComponent<RecoilScript>();
        recoilControl.setDefaults(transform.localPosition, transform.localRotation);
        trigger_held = false;
        //burst_limit = 3;
        burst_count_to_max = 0;
        //reburst_delay = 0.0f;
        refire_delay = 0.0f;
    }

    // Update is called once per frame
    void Update()

    {
        refire_delay -= Time.deltaTime;
        //reburst_delay -= Time.deltaTime;

        //if (trigger_held == true)
        if (trigger_held == false)
        {
            burst_count_to_max = 0;

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
