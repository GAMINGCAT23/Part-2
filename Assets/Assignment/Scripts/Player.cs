using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 Des;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rigidbody;
    Animator animator;
    //public float health;
    //public float maxHealth = 5;
    //public HealthBar1 healthBar1;
    bool isDead = false;
    public float LeftHealth;
    bool isAttack = false;
    public float Timer = 0;
    public float TargetTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //health = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead) return;
        movement = Des - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }
    //public void SendHP()
    //{
        //healthBar1.SendMessage("SetHealth", health, SendMessageOptions.DontRequireReceiver);
    //}
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            Des = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
            isAttack = true;
            if (isAttack = true)
            {
                Timer = Timer + Time.deltaTime;
                if (Timer > TargetTime)
                {
                    Timer = 0;
                    isAttack = false;
                }
            }

        }

        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDead) return;
        //takeDamage(1);
        //healthBar1.TakeDamage(1);
        if (isAttack)
        {
            Destroy(collision.gameObject);
            isAttack=false;
        }
    }

    //public void takeDamage(float damage)
    //{
        //Debug.Log(damage);
        //Debug.Log(health);
        //health -= damage;   
        //health = Mathf.Clamp(health, 0, maxHealth);
        //if (health == 0)
        //{
            //die?
            //animator.SetTrigger("Death");
            //isDead = true;
        //}
        //else
        //{
            //animator.SetTrigger("TakeDamage");
            //isDead = false;
        //}
    //}
}
