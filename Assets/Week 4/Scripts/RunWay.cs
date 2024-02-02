using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWay : MonoBehaviour
{
    Collider2D Runway;
    // Start is called before the first frame update
    void Start()
    {
        Runway = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.GetComponent<Plane>().AllowLanding = true;
        }
    }
}
