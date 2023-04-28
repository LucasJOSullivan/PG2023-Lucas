using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform template, spawnPoint;
    float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Instantiate(template, spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);
        }
    }

    internal void IveBeenDestroyed(Transform parent)
    {

    }
}
