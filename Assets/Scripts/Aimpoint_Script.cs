using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimpoint_Script : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target, Vector3.up);
        transform.Rotate(90.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target, Vector3.up);
        transform.Rotate(90.0f,0.0f,0.0f);
    }
}
