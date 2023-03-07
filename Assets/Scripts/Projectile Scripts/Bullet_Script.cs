using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    Rigidbody rb;
    bool live;
    float dragsum, drag, speed;
    Vector3 velocity, gravity;
    //public ConstantForce gravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        speed = 5.00f;
        rb.velocity  =  transform.forward * speed;
     
     
        //drag = 1.00f;
        //dragsum  = (speed -= drag) * Time.deltaTime;

        //gravity = gameObject.AddComponent<ConstantForce>();
        //gravity.force = new Vector3(0.0f, -9.81f, 0.0f);
    }

    // Update is called once per frame
    void Update()

    {
        rb.AddForce(new Vector3(0.00f, -9.81f, 0.00f));
       // gravity = new Vector3(0.00f, -9.81f, 0.00f);
      //  velocity += gravity * Time.deltaTime;
     //   transform.position += velocity * Time.deltaTime;
    }

    /*
    void FixedUpdate()
    {

        if (live = false)
        {            
            Destroy(this);
        }
    }
    */

    
    void OnCollisionEnter(Collision collision)
    {
        speed = 0.00f;
    //    live = false;
    }
    

}
