using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement : MonoBehaviour
{
    public float health;
    public float maxHealth = 5;
    public HealthBar1 healthBar1;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TakeDamageFromMonster(1);
        //healthBar1.TakeDamage(1);
        //Destroy(collision.gameObject);
    }

    public void TakeDamageFromMonster(float damage) 
    {
        Debug.Log(damage);
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        SendMessage("SetHealth", health, SendMessageOptions.DontRequireReceiver);
        Debug.Log(health);
    }
}
