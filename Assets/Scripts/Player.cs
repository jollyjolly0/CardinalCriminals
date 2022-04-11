using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int maxSupportedPlayers = 2;

    [Range(1, maxSupportedPlayers)]
    public int playerNumber;

}
