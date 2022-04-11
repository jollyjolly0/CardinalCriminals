using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{
    public int damage;
    public float speed;

    [HideInInspector]
    public Vector2 direction;

    [HideInInspector]
    public GameObject attackSource;

    private void Start()
    {
        attackSource = gameObject.transform.root.gameObject;

        foreach (var item in GetComponentsInChildren<HitBox>())
        {
            item.SetAttack(this);
        }
    }
}

public delegate void OnHitEvent(Attack attack);