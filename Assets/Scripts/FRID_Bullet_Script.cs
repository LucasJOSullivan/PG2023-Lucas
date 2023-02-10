using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRID_Bullet_Script : MonoBehaviour
{
    Rigidbody rb;
    bool live, freefall;
    float dragsum, drag, xspeed, yspeed, zspeed;
    Vector3 velocity, gravity;
    //public ConstantForce gravity;

    // Start is called before the first frame update
    void Start()
    {
        freefall = false;
        rb = GetComponentInChildren<Rigidbody>();
        zspeed = 250.00f;
        rb.velocity = transform.forward * zspeed;


        //drag = 1.00f;
        //dragsum  = (speed -= drag) * Time.deltaTime;

        //gravity = gameObject.AddComponent<ConstantForce>();
        //gravity.force = new Vector3(0.0f, -9.81f, 0.0f);
    }

    // Update is called once per frame
    void Update()

    {
        // gravity = new Vector3(0.00f, -9.81f, 0.00f);
        //  velocity += gravity * Time.deltaTime;
        //   transform.position += velocity * Time.deltaTime;
    }


    void FixedUpdate()
    {
        while (freefall == false)
        {
            rb.AddForce(0, 0, zspeed, ForceMode.VelocityChange);
            freefall = true;
        }

        //WaitForSeconds;
        rb.AddForce(new Vector3(0.00f, -9.81f, 0.00f));
        /*

            if (live = false)
            {            
                Destroy(this);
            }
        }
        */


        void OnCollisionEnter(Collision collision)
        {
            freefall = true;
            //    live = false;
        }


    }
}
