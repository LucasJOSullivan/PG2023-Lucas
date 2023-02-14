using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRID_Bullet_Script : MonoBehaviour
{
    CapsuleCollider ccp;
    CapsuleCollider ccc;
    Rigidbody rb;
    Light li;

    bool live, freefall;
    float dragsum, drag, xspeed, yspeed, zspeed, lifetime;
    Vector3 velocity, gravity;
    private float timer;

    //public ConstantForce gravity;

    // Start is called before the first frame update
    void Start()
    {
        live = true;
        lifetime = 100;
        freefall = false;
        ccp = GetComponent<CapsuleCollider>();
        ccc = GetComponentInChildren<CapsuleCollider>();
        rb = GetComponentInChildren<Rigidbody>();
        li = GetComponentInChildren<Light>();


        zspeed = 100.00f;
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
        timer += Time.deltaTime;
        ccp.enabled = true;
        ccc.enabled = true;
        while (freefall == false)
        
        {
            /*
            rb.AddForce(0, 0, zspeed, ForceMode.VelocityChange);
            */
            freefall = true;
            
        }

        if (live == false)
        {
            lifetime = Mathf.Lerp(1, 0, timer);
            li.intensity = Mathf.Lerp(1, 0, timer * 4);
        }

        if (lifetime == 0)
        {
            Destroy(gameObject);
        }

        //WaitForSeconds;
        //rb.AddForce(0f, rb.mass * -9.81f, 0f);

        /*
        if (live == false)
            {            
                Destroy(this);
            }
        */
        }
 

    void OnCollisionEnter(Collision collision)
    {
        if (live == true)
        {
            live = false;
        }
    }

    }
