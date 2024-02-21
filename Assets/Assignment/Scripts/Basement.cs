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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamageFromMonster(1);
        //Destroy(collision.gameObject);
    }

    public void TakeDamageFromMonster(float damage) 
    {
        Debug.Log(damage);
        Debug.Log(health);
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar1.SendMessage("SetHealth", health, SendMessageOptions.DontRequireReceiver);
    }
}
