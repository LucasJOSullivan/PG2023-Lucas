using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    bool live;
    float drag, gravity, velocity;
    // Start is called before the first frame update
    void Start()
    {
        live = true;
        drag = 1.00f;
        gravity = 9.81f;
        velocity = 250.00f;  
    }

    // Update is called once per frame
    void Update()
    {
        if (live = false)
        {
            Destroy(this);
        }
    }
    void OnCollisionEnter (Collision collision)
    {
        live = false;
        
    }
}
