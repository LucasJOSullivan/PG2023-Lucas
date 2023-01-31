using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
//    float rotX, rotY;
    float xyAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        rotX = Input.GetAxis("Horizontal");

    }

    internal void UpdatePosition(Player_Movement myMan,  float vertical)
    {
        transform.position = myMan.transform.position + Vector3.up;
        //transform.rotation = myMan.transform.rotation;
        //xyAngle += horizontal;
        zAngle -= vertical;
        zAngle = Mathf.Clamp(zAngle, -60, +60);

        transform.rotation = Quaternion.AngleAxis(zAngle,myMan.transform.right) * myMan.transform.rotation;
        transform.LookAt(transform.position + transform.forward, Vector3.up);
    }
}