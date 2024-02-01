using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWay : MonoBehaviour
{
    public float points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.OverlapPoint(collision.gameObject.transform.position))
        {

            Destroy(collision.gameObject);
            points = points + 1;
        }
    }
}
