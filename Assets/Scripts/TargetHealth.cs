using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour, IHealth
{
    ScoreTracker playerScore;
    GameObject scoreObject;

    //GetComponentByName<
    //GameObject.Find("Score Display").GetComponent<ScoreTracker>();
    public AudioSource source;
    public AudioClip clip;
    public float volume = 0.5f;
    float value;

    public Transform spawnPoint, templateOne, templateTwo;



    public float health;
    //string nameCheck;
    MeshCollider detectCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = FindObjectOfType<ScoreTracker>();
        scoreObject = GameObject.Find("Score Display");
        health = 100f;
        //detectCollider = GetComponentInChildren<MeshCollider>;
        MeshCollider[] allColliders = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider target in allColliders)
        {
            if (target.name == "Target Face")
                detectCollider = target;
        }
        /*
        if (detectCollider)
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


    public void takeDamage(float incomingDamage)
    {
        health -= incomingDamage;
        if (health <= 0f)
        {
            selfDestruct();
        }
        //print("4");
    }

    public void selfDestruct()
    {
        playerScore.addScore();
        Instantiate(templateOne, spawnPoint.position, spawnPoint.rotation);
        Instantiate(templateTwo, spawnPoint.position, spawnPoint.rotation);
        Destroy(transform.parent.gameObject);
    }
}
