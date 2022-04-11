using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum Source
{
    Enemy
}

[System.Serializable]
public class Attack
{
    public int damage;
    public Source source;

    [HideInInspector]
    public GameObject attackSource;
}

public delegate void OnHitEvent(Attack attack);