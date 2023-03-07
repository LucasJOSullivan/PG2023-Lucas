using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    IShoot myGun;
    //public Transform spawnpoint, bulletCloneTemplate;
    FPSCameraScript camera;
    private float speed;
    private float turnSpeed;
    const float WALKING_SPEED = 3, RUNNING_SPEED = 8, CROUCH_SPEED = 1;
    const float WALKING_TURN = 90, RUNNING_TURN = 45, CROUCH_TURN = 90;
    // Start is called before the first frame update
    void Start()
    {
        speed = WALKING_SPEED;
        turnSpeed = WALKING_TURN;
        camera = FindObjectOfType<FPSCameraScript>();

        myGun = camera.GetComponentInChildren<IShoot>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.LeftShift) && (!Input.GetKey(KeyCode.LeftControl)))
        {
            speed = RUNNING_SPEED;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && (!Input.GetKey(KeyCode.LeftShift)))
        {
            speed = CROUCH_SPEED;
        }
        else 
        {
            speed = WALKING_SPEED;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            myGun.triggerPressed();
        }

        if (Input.GetMouseButton(0))
        {
            myGun.triggerHeld();
        }

        if (!Input.GetMouseButton(0))
        {
            myGun.triggerReleased();
        }

        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
        camera.UpdatePosition(this, Input.GetAxis("Vertical"));
    }

    // FixedUpdate is called once per game tick
    void FixedUpdate()
    {
        
    }
}
