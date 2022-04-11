using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Attack
{
    public int damage;

    [HideInInspector]
    public GameObject attackSource;
}

public delegate void OnHitEvent(Attack attack);