using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
    public Slider slider;

    public void TakeDamageFromMonster(float damage)
    {
        slider.value -= damage;
        Debug.Log("TakeDamage");

    }
    public void Sethealth(float health)
    {
        slider.value = health;
    }
}
