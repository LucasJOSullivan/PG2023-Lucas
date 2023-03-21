using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    enum recoilState { None, Recoiling, Returning}

    Vector3 defaultPosition, startingPosition;
    Quaternion defaultOrientation;
    recoilState currently = recoilState.None;
    Vector3 destination;
    Quaternion destinationOrientation, startingOrientation;

    float timer;
    public bool allowAutoRotationRecovery, allowAutoMovementRecovery;
    public float cooldownTime, rotationClamp, movementClamp,

        upwardRotation, rightwardRotation, downwardRotation, leftwardRotation,
        upwardRotationLimit, rightwardRotationLimit, downwardRotationLimit, leftwardRotationLimit,
        upwardRotationChance, rightwardRotationChance, downwardRotationChance, leftwardRotationChance,

        forwardMovement, rearwardMovement, upwardMovement, rightwardMovement, downwardMovement, leftwardMovement,
        forwardMovementLimit, rearwardMovementLimit, upwardMovementLimit, rightwardMovementLimit, downwardMovementLimit, leftwardMovementLimit,
        forwardMovementChance, rearwardMovementChance, upwardMovementChance, rightwardMovementChance, downwardMovementChance, leftwardMovementChance;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        switch(currently)
        {
            case recoilState.Recoiling:

                transform.localPosition = Vector3.Lerp(startingPosition, destination, timer);
                transform.localRotation = Quaternion.Slerp(startingOrientation, destinationOrientation, timer);

                timer += Time.deltaTime;

                if (timer >1 )
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


                transform.localPosition = Vector3.Lerp(startingPosition, destination, timer);
                transform.localRotation = Quaternion.Slerp(startingOrientation, destinationOrientation, timer);

                timer += Time.deltaTime;

                if (timer > 1)
                {
                    transform.position = defaultPosition;
                    transform.rotation = defaultOrientation;
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

        destinationOrientation = getMaximumrecoilOrientation();


    }

    internal void setDefaults(Vector3 defaultLocalPosition,Quaternion defaultLocalOrientation)
    {
        defaultPosition = defaultLocalPosition;
        defaultOrientation = defaultLocalOrientation;
    }

    private Quaternion getMaximumrecoilOrientation()
    {
        return Quaternion.AngleAxis(45, transform.right);
    }

    private Vector3 getRandomRecoilPosition()
    {
        return new Vector3(0, 1, -1);
    }
}
