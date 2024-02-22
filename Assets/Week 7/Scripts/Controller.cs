using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Slider ChargeSlider;
    float chargeValue;
    public float MaxCharge = 1;
    Vector2 direction;
    public static player selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(player player)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.selected(false);
        }
        selectedPlayer = player;
        selectedPlayer.selected(true);
    }
    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            ChargeSlider.value = chargeValue;
        }
    }

    private void Update()
    {
        if (selectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, MaxCharge);
            ChargeSlider.value = chargeValue;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * chargeValue;
        }
    }
}
