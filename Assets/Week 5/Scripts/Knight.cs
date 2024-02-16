using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rigidbody;
    Animator animator;
    bool clickingOnSelf = false;
    public float health = 5;
    public float maxHealth = 5;
    public HealthBar healthBar;
    bool isDead = false;
    public float LeftHealth;
    //1
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = PlayerPrefs.GetFloat("LeftHealth", maxHealth);
        Debug.Log(health);
        SendMessage("Sethealth", health);
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);
    }

    public void LoadHealth()
    {
        LeftHealth = PlayerPrefs.GetFloat("LeftHealth", health);
    }

    public void SendHP()
    {
        healthBar.SendMessage("SetHealth", health, SendMessageOptions.DontRequireReceiver);
        Debug.Log("MSG SENT");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");

        }

        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        takeDamage(1);
        healthBar.TakeDamage(1);
        //1

    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void takeDamage(float damage)
    {
        Debug.Log(damage);
        Debug.Log(health);
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        PlayerPrefs.SetFloat("LeftHealth", health);
        if (health == 0)
        {
            //die?
            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            animator.SetTrigger("TakeDamage");
            isDead = false;
        }
    }
}
