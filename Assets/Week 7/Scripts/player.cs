using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color DefultColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = DefultColor;
        selected(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    //private void OnMouseUp()
    //{
        //selected(false);
    //}

    public void selected(bool playerBeenSelected) 
    {
        if (playerBeenSelected)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = DefultColor;
        }
    }
}
