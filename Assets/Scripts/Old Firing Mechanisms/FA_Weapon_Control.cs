using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FA_Weapon_Control : MonoBehaviour, IShoot
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;

    float refire_delay;
    public Transform spawnpoint, bulletCloneTemplate;

    public void triggerHeld()
    {
        if (refire_delay <= 0.0f)
        {
            Instantiate(bulletCloneTemplate, spawnpoint.position, spawnpoint.rotation);
            audioSource.PlayOneShot(audioClip, volume);
            refire_delay = 0.1f;
        }
    }

    public void triggerReleased()
    {

    }

    public void triggerPressed()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        refire_delay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        refire_delay -= Time.deltaTime;
    }

    void FixedUpdate()
    {

    }
}
