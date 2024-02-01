using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public float spawnPoint;
    float Timer = 0;
    float TargetTime = 3;
    float randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = Random.Range(-5, 5);
        //InvokeRepeating("SpawnPlane", 2+Time.deltaTime, 3+Time.deltaTime);
    }

    void SpawnPlane() 
    { 

    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        //randomNumber = Random.Range(-5, 5);
        Vector3 vector3 = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

        if (Timer > TargetTime)
        {
            Instantiate(plane, vector3, transform.rotation);
            Timer = 0;
        }
        else 
        {
            
        }
    }
}
