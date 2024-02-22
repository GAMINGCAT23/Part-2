using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
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
}
