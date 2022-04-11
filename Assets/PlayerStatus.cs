using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool isAlive;
    public delegate void PlayerDeath();
    public event PlayerDeath onPlayerDeath;

    public void Die()
    {
        isAlive = false;
        onPlayerDeath.Invoke();
    }
}
