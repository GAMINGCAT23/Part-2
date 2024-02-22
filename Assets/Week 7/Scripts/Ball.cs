using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    //public float score;
    Vector3 kickOffPos;
    // Start is called before the first frame update
    void Start()
    {
        kickOffPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score++;
        Debug.Log(Controller.score);
        transform.position = kickOffPos;
        rb.velocity = Vector3.zero;
    }
}
