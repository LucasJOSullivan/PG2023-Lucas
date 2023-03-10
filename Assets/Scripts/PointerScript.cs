using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{

    public float secondsBetweenUpdates;
    float timer;
    Transform myCam;
    // Start is called before the first frame update
    void Start()
    {
        FPSCameraScript myCamScript = FindObjectOfType<FPSCameraScript>();
        myCam = myCamScript.transform;
        //offset = 1.1f;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            timer = secondsBetweenUpdates;
            //LayerMask mask = LayerMask.GetMask("Player Object");
            RaycastHit info;

            if (Physics.Raycast(new Ray(myCam.position + 1.5f * myCam.forward, myCam.forward), out info))
            {
                transform.position = info.point;
            }
            /*
            else if (Physics.Raycast(new Ray(myCam.position + myCam.forward * 1, myCam.forward, mask), out info))
            {

            }
            */
        }
        
    }
}
