using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Vector2 center;
    Vector2 movement;
    public float speed = 2;
    Rigidbody2D rigidbody;
    Animator animator;
    public float TargetTime = 1.5f;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        center = Vector3.zero;
        //center = Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        movement = center - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }

    //public void Death() 
    //{
        //animator.SetTrigger("Death");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!isDead) return;
        collision.gameObject.SendMessage("TakeDamageFromMonster", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
    }
}