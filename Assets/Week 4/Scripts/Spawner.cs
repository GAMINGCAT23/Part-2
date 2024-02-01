using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public float spawnPoint;
    float Timer = 0;
    float TargetTime;
    float randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        //randomNumber = Random.Range(-5, 5);

        if (Timer > TargetTime)
        {
            Instantiate(plane);
            Timer = 0;
            TargetTime = Random.Range(1, 5);
        }
        else
        {

        }
    }
}
