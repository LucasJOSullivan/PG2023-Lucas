using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    enum recoilState {None, Recoiling, Returning}
    public float recoilTime = 0.02f, returnTime = 0.02f;
    Vector3 defaultPosition, startingPosition;
    public Vector3 positionClamp;
    Quaternion defaultOrientation, startingOrientation, destinationOrientation;
    public Quaternion orientationClamp;

    recoilState currently = recoilState.None;
    Vector3 destination;    
    Aimpoint_Script aim;



    float timer;
    /*
      float fDefaultPosition, fStartingPosition, fDestinationOrientation, fStartingOrientation;
    
      public Vector3 recoilDirection1, recoilDirection2, recoilDirection3, recoilDirection4,
        recoilDirection5, recoilDirection6, recoilDirection7, recoilDirection8;
    //public Quaternion
    public bool allowAutoRotationRecovery, allowAutoMovementRecovery;
    public float cooldownTime, rotationClamp, movementClamp,

        upwardRotation, rightwardRotation, downwardRotation, leftwardRotation,
        upwardRotationLimit, rightwardRotationLimit, downwardRotationLimit, leftwardRotationLimit,
        upwardRotationChance, rightwardRotationChance, downwardRotationChance, leftwardRotationChance,

        forwardMovement, rearwardMovement, upwardMovement, rightwardMovement, downwardMovement, leftwardMovement,
        forwardMovementLimit, rearwardMovementLimit, upwardMovementLimit, rightwardMovementLimit, downwardMovementLimit, leftwardMovementLimit,
        forwardMovementChance, rearwardMovementChance, upwardMovementChance, rightwardMovementChance, downwardMovementChance, leftwardMovementChance;
    */


    // Start is called before the first frame update
    void Start()
    {
        //fDefaultPosition = defaultPosition;
        timer = 0.0f;
        aim = GetComponentInChildren<Aimpoint_Script>();

    }

    // Update is called once per frame
    void Update()
    {

        switch(currently)
        {
            case recoilState.Recoiling:
                transform.localPosition = Vector3.Lerp(startingPosition, destination, timer/recoilTime);
                transform.localRotation = Quaternion.Slerp(startingOrientation, destinationOrientation, timer/recoilTime);

                timer += Time.deltaTime;

                if (timer > recoilTime )
                {
                    currently = recoilState.Returning;
                    startingPosition = destination;
                    destination = defaultPosition;
                    startingOrientation = destinationOrientation;
                    destinationOrientation = defaultOrientation;
                    timer = 0;
                }
                break;



            case recoilState.Returning:               
                transform.localPosition = Vector3.Lerp(startingPosition, destination, timer/returnTime);
                transform.localRotation = Quaternion.Slerp(startingOrientation, destinationOrientation, timer/returnTime);
                
                timer += Time.deltaTime;

                if (timer > returnTime)
                {
                    transform.localPosition = defaultPosition;
                    transform.localRotation = defaultOrientation;
                    aim.recoilOver();
                    currently = recoilState.None;
                }
                break;

        }

    }

    internal void startRecoil()
    {
        currently = recoilState.Recoiling;
        timer = 0;
        destination = getRandomRecoilPosition();
        startingPosition = transform.localPosition;
        startingOrientation = transform.localRotation;
        aim.startingRecoil();
        destinationOrientation = getMaximumrecoilOrientation();


    }

    internal void setDefaults(Vector3 defaultLocalPosition,Quaternion defaultLocalOrientation)
    {
        defaultPosition = defaultLocalPosition;
        defaultOrientation = defaultLocalOrientation;
    }

    private Quaternion getMaximumrecoilOrientation()
    {
        return Quaternion.AngleAxis(-7.5f, Vector3.right);
    }

    private Vector3 getRandomRecoilPosition()
    {
        return defaultPosition + new Vector3(0, -0.025f, 0.05f);
    }
}
