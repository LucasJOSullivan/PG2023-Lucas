using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    MeshCollider targetCollider;

    // Start is called before the first frame update
    void Start()
    {
/*
        MeshCollider[] allColliders = GetComponents<MeshCollider>();
        foreach (MeshCollider target in allColliders)
        {
            if (target.name == "Target Face")
                targetCollider = target;
        }
        if (targetCollider)
        {
            print("Found Target");

        }
        else print("Warning Target not found");
*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
