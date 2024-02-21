using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class MonsterS : MonoBehaviour
{
    public GameObject Monster;
    public Transform MonsterSpawner;
    float Timer = 0;
    float TargetTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;

        if (Timer > TargetTime)
        {
            Instantiate(Monster, MonsterSpawner);
            Timer = 0;
            TargetTime = Random.Range(5, 10);
        }
        else
        {

        }
    }
}
