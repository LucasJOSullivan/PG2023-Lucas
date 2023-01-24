using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    float xyAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void UpdatePosition(Player_Movement myMan, float horizontal, float vertical)
    {
        transform.position = myMan.transform.position;
        //transform.rotation = myMan.transform.rotation;
        xyAngle += horizontal;
        zAngle += vertical;

        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.right) * Quaternion.AngleAxis(xyAngle, Vector3.up);
        transform.LookAt(transform.position + transform.forward, Vector3.up);
    }
}