using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Weapon_Control : MonoBehaviour, IShoot
{
    public Transform spawnpoint, bulletCloneTemplate;
    private bool triggerAlreadyPressed = false;
    private int counter, checkCounter = 0;

    public void triggerHeld()
    {
    }

    public void triggerReleased()
    {

    }

    public void triggerPressed()
    {
        counter += 1;

        if (!triggerAlreadyPressed)
        {
            fireBullet();
            checkCounter = counter;
        }
    }

    private void fireBullet()
    {
        Instantiate(bulletCloneTemplate, spawnpoint.position, spawnpoint.rotation);
        triggerAlreadyPressed = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        checkCounter++;


        if ((checkCounter - counter) > 2)
            triggerAlreadyPressed = false;

    }
}
