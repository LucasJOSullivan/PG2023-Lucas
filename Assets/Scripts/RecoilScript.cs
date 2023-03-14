using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    public bool allowAutoRotationRecovery, allowAutoMovementRecovery;
    public float cooldownTime,
        upwardRotation, rightwardRotation, downwardRotation, leftwardRotation,
        upwardRotationLimit, rightwardRotationLimit, downwardRotationLimit, leftwardRotationLimit,
        upwardRotationChance, rightwardRotationChance, downwardRotationChance, leftwardRotationChance,

        forwardMovement, rearwardMovement, upwardMovement, rightwardMovement, downwardMovement, leftwardMovement,
        forwardMovementLimit, rearwardMovementLimit, upwardMovementLimit, rightwardMovementLimit, downwardMovementLimit, leftwardMovementLimit,
        forwardMovementChance, rearwardMovementChance, upwardMovementChance, rightwardMovementChance, downwardMovementChance, leftwardMovementChance;

    float cooldown_timer;
    // Start is called before the first frame update
    void Start()
    {
        cooldown_timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
