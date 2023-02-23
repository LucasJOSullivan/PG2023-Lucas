using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    //    float rotX, rotY;
    //public GameObject camera;
    float xyAngle, zAngle, distance;
    public Transform pointerTemplate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Ray pointerRay = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        //if (Physics.Raycast(pointerRay, transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        if (Physics.Raycast(pointerRay, out hit, distance))
        {
            if (hit.collider.tag != "Player Object")
            {
                //Instantiate(pointerTemplate, hit.position, hit.rotation);
                Instantiate(pointerTemplate, hit.position);
            }
        }
        */

        //        rotX = Input.GetAxis("Horizontal");
    }

    internal void UpdatePosition(Player_Control myMan, float vertical)
    {
        transform.position = myMan.transform.position + Vector3.up;
        //transform.rotation = myMan.transform.rotation;
        //xyAngle += horizontal;
        zAngle -= vertical;
        zAngle = Mathf.Clamp(zAngle, -60, +60);

        transform.rotation = Quaternion.AngleAxis(zAngle, myMan.transform.right) * myMan.transform.rotation;
        transform.LookAt(transform.position + transform.forward, Vector3.up);
    }
}