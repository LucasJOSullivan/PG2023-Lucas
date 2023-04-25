using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform cloneTemplate;

    // Start is called before the first frame update
    void Start()
    {
      spawnLocationScript[] allLocations = FindObjectsOfType<spawnLocationScript>();

      foreach (spawnLocationScript location in allLocations)
        {
            Instantiate(cloneTemplate, location.transform.position, Quaternion.LookRotation( (Camera.main.transform.position - location.transform.position).normalized ), location.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void IveBeenDestroyed(Transform parent)
    {
        print("Hello");
        Instantiate(cloneTemplate, parent.position, Quaternion.LookRotation((Camera.main.transform.position - parent.position).normalized), parent);
    }
}
