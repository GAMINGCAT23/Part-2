using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject Weapon;
    public Transform Spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        createweapon();
    }
    public void createweapon()
    {
        Instantiate(Weapon, Spawn.position, Spawn.rotation);
    }
}
